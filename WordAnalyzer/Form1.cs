using System.Diagnostics;

namespace WordAnalyzer
{
    public partial class Form1 : Form
    {
        private string bookText = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //
        //}
        //
        //private void button2_Click(object sender, EventArgs e)
        //{
        //
        //}

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    richTextBoxDisplay.Text = fileContent;
                }
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBoxDisplay.Text))
            {
                MessageBox.Show("Please load a text file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var analysisResults = AnalyzeText(richTextBoxDisplay.Text);

            stopwatch.Stop();
            long elapsedTime = stopwatch.ElapsedMilliseconds;

            // Add elapsed time to results
            analysisResults.Add("Elapsed Time (ms)", $"{elapsedTime} ms");

            // Show the results in Form2
            Form2 resultsForm = new Form2(analysisResults);
            resultsForm.Show();
        }

        // Method to analyze text 
        private Dictionary<string, string> AnalyzeText(string text)
        {
            // Define the valid word delimiters
            char[] delimiters = { ' ', '\n', '\r', '\t', '.', ',', ';', '!', '?', '"', '\'', '(', ')', '-', '_', ':', '/', '[', ']', '{', '}' };

            // Split text into words
            var words = new List<string>();
            string[] splitWords = text.ToLower().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in splitWords)
            {
                // Remove any remaining punctuation and check length
                string cleanedWord = RemovePunctuation(word);
                if (cleanedWord.Length >= 3) // Only include words 3+ characters
                {
                    words.Add(cleanedWord);
                }
            }

            // Word stats
            int wordCount = words.Count;
            string shortestWord = words[0];
            string longestWord = words[0];
            int totalLength = 0;

            // Dictionary to count word occurrences
            var wordFrequency = new Dictionary<string, int>();

            foreach (string word in words)
            {
                totalLength += word.Length;

                // Update shortest and longest words
                if (word.Length < shortestWord.Length) shortestWord = word;
                if (word.Length > longestWord.Length) longestWord = word;

                // Count word occurrences
                if (wordFrequency.ContainsKey(word))
                    wordFrequency[word]++;
                else
                    wordFrequency[word] = 1;
            }

            // Calculate average word length
            double averageWordLength = (double)totalLength / wordCount;

            // Find most and least common words
            var mostCommonWords = GetTopWords(wordFrequency, true, 5);
            var leastCommonWords = GetTopWords(wordFrequency, false, 5);

            // Format results
            var results = new Dictionary<string, string>
            {
                { "Total Words", wordCount.ToString() },
                { "Shortest Word", shortestWord },
                { "Longest Word", longestWord },
                { "Average Word Length", averageWordLength.ToString("F2") },
                { "Most Common Words", string.Join(", ", mostCommonWords) },
                { "Least Common Words", string.Join(", ", leastCommonWords) }
            };

            return results;
        }

        // Get top N most or least common words
        private List<string> GetTopWords(Dictionary<string, int> wordFrequency, bool mostCommon, int count)
        {
            var sortedWords = new List<KeyValuePair<string, int>>(wordFrequency);

            // Sort words manually
            for (int i = 0; i < sortedWords.Count - 1; i++)
            {
                for (int j = i + 1; j < sortedWords.Count; j++)
                {
                    if (mostCommon && sortedWords[j].Value > sortedWords[i].Value)
                    {
                        var temp = sortedWords[i];
                        sortedWords[i] = sortedWords[j];
                        sortedWords[j] = temp;
                    }
                    else if (!mostCommon && sortedWords[j].Value < sortedWords[i].Value)
                    {
                        var temp = sortedWords[i];
                        sortedWords[i] = sortedWords[j];
                        sortedWords[j] = temp;
                    }
                }
            }

            //Get top N words
            var result = new List<string>();

            for (int i = 0; i < Math.Min(count, sortedWords.Count); i++)
            {
                result.Add($"{sortedWords[i].Key} ({sortedWords[i].Value})");
            }

            return result;
        }

        // Remove punctuation from a word
        private string RemovePunctuation(string word)
        {
            var cleanedWord = new List<char>();

            foreach (char c in word)
            {
                if (char.IsLetterOrDigit(c)) // Include only letters and digits
                {
                    cleanedWord.Add(c);
                }
            }

            return new string(cleanedWord.ToArray());
        }
    }
}
