import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {
    public static void main(String[] args) {
        String text = "This is an example text. This text contains several sentences. Some of them contain the same words 123. For example, the word 'text' occurs twice.";

        // 1
        System.out.println("1");
        int maxSentencesWithSameWords = getMaxSentencesWithSameWords(text);

        System.out.println("Maximum number of sentences with the same words: " + maxSentencesWithSameWords);

        // 2
        System.out.println(" ");
        System.out.println("2");
        List<String> sortedSentences = sortSentencesByWordCount(text);

        System.out.println("Sentences sorted by word count:");
        for (String sentence : sortedSentences) {
            System.out.println(sentence);
        }

        // 3
        System.out.println(" ");
        System.out.println("3");
        String[] sentences = text.split("[.!?]\\s*");

        // Get words from the first sentence
        String[] firstSentenceWords = sentences[0].split("\\s+");

        // Create a set to store words from other sentences
        Set<String> otherSentencesWords = new HashSet<>();

        // Add words from other sentences to the set
        for (int i = 1; i < sentences.length; i++) {
            String[] words = sentences[i].split("\\s+");
            otherSentencesWords.addAll(Arrays.asList(words));
        }

        // Find the word from the first sentence that is not in any of the other sentences
        String uniqueWord = null;
        for (String word : firstSentenceWords) {
            if (!otherSentencesWords.contains(word)) {
                uniqueWord = word;
                break;
            }
        }

        if (uniqueWord != null) {
            System.out.println("The word from the first sentence that is not in any of the other sentences: " + uniqueWord);
        } else {
            System.out.println("All words from the first sentence occur in the other sentences.");
        }

        // 4
        System.out.println(" ");
        System.out.println("4");
        findWordsInInterrogativeSentences(text, 5);

        // 5. In each sentence of the text, swap the first and last words without changing the length of the sentence.
        System.out.println(" ");
        System.out.println("5");
        String[] sentences2 = text.split("[.!?]\\s*");

        StringBuilder modifiedText = new StringBuilder();

        for (String sentence : sentences2) {
            String[] words = sentence.split("\\s+");

            if (words.length > 1) {
                String firstWord = words[0];
                words[0] = words[words.length - 1];
                words[words.length - 1] = firstWord;

                StringBuilder modifiedSentence = new StringBuilder();
                for (String word : words) {
                    modifiedSentence.append(word).append(" ");
                }

                modifiedText.append(modifiedSentence.toString().trim()).append(". ");
            } else {
                modifiedText.append(sentence).append(". ");
            }
        }

        System.out.println("Text with modified sentences:");
        System.out.println(modifiedText.toString().trim());
    }

    // 1. Find the maximum number of sentences in the text that contain the same words.
    public static int getMaxSentencesWithSameWords(String text) {
        String[] sentences = text.split("[.!?]\\s*");

        int maxCount = 0;
        for (String sentence : sentences) {
            String[] words = sentence.split("\\s+");
            Set<String> uniqueWords = new HashSet<>(Arrays.asList(words));
            if (uniqueWords.size() < words.length) {
                maxCount++;
            }
        }

        return maxCount;
    }

    // 2. Print all sentences of the given text in ascending order of the number of words in each of them.
    public static List<String> sortSentencesByWordCount(String text) {
        String[] sentences = text.split("[.!?]\\s*");

        List<String> sentenceList = Arrays.asList(sentences);
        List<String> sortedSentences = new ArrayList<>(sentenceList);
        sortedSentences.sort(Comparator.comparingInt(Main::countWordsInSentence));

        return sortedSentences;
    }

    public static int countWordsInSentence(String sentence) {
        String[] words = sentence.split("\\s+");
        return words.length;
    }

    // 4. In all interrogative sentences of the text, find and print unique words of a specified length without repetitions.
    public static void findWordsInInterrogativeSentences(String text, int wordLength) {
        Pattern pattern = Pattern.compile("[^.!?]+\\?");
        Matcher matcher = pattern.matcher(text);

        Set<String> uniqueWords = new HashSet<>();

        while (matcher.find()) {
            String interrogativeSentence = matcher.group().trim();
            String[] words = interrogativeSentence.split("\\s+");
            for (String word : words) {
                if (word.length() == wordLength) {
                    uniqueWords.add(word.toLowerCase());
                }
            }
        }

        if (!uniqueWords.isEmpty()) {
            System.out.println("Unique words of the specified length in interrogative sentences:");
            for (String word : uniqueWords) {
                System.out.println(word);
            }
        } else {
            System.out.println("There are no words of the specified length in interrogative sentences.");
        }
    }
}
