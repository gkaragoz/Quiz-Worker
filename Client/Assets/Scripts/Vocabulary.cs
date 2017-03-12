using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vocabulary : MonoBehaviour {

    [System.Serializable]
    public class Word {
        [SerializeField] private string word;
        [SerializeField] private string translate;

        public Word(string word, string translate)
        {
            this.word = word;
            this.translate = translate;
        }

        public string GetWord()
        {
            return word;
        }

        public string GetTranslate()
        {
            return translate;
        }
    }

    [SerializeField] public List<Word> Vocabularies = new List<Word>();
    private int questionCounter;

    public Text txtQuestion;
    public List<Button> Buttons = new List<Button>();

    public Color ColorCorrect;
    public Color ColorWrong;

    private void Start()
    {
        questionCounter = 0;
        FillWords();
        AssignNewQuestion();
    }

    private void FillButtonColorsToWhite()
    {
        foreach (var item in Buttons)
            item.GetComponent<Image>().color = Color.white;
    }

    private void AssignNewQuestion()
    {
        FillButtonColorsToWhite();

        Word word = Vocabularies[questionCounter];
        txtQuestion.text = word.GetWord();
        int number = Random.Range(0, Buttons.Count);

        for (int ii = 0; ii < Buttons.Count; ii++)
        {
            if (ii == number)
                Buttons[number].transform.FindChild("Text").GetComponent<Text>().text = GetCorrectAnswer(word);
            else
                Buttons[ii].transform.FindChild("Text").GetComponent<Text>().text = GetRandomTranslate(word);
        }
    }

    private string GetRandomTranslate(Word word)
    {
        var tempList = new List<Word>();
        foreach (var item in Vocabularies)
            tempList.Add(item);

        tempList.Remove(word);

        return tempList[Random.Range(0, tempList.Count)].GetTranslate();
    }

    private string GetCorrectAnswer(Word word)
    {
        return word.GetTranslate();
    }

    public void onClickNewQuestion()
    {
        Debug.Log(questionCounter);
        Debug.Log(Vocabularies.Count);
        if (questionCounter >= Vocabularies.Count - 1)
            questionCounter = 0;
        else
            questionCounter++;

        AssignNewQuestion();
    }

    public void onClickButton(string answerNumber)
    {
        int buttonNumber = -1;

        if (answerNumber == "1")
            buttonNumber = int.Parse(answerNumber) - 1;
        else if (answerNumber == "2")
            buttonNumber = int.Parse(answerNumber) - 1;
        else if (answerNumber == "3")
            buttonNumber = int.Parse(answerNumber) - 1;
        else if (answerNumber == "4")
            buttonNumber = int.Parse(answerNumber) - 1;
        else if (answerNumber == "5")
            buttonNumber = int.Parse(answerNumber) - 1;

        if(Buttons[buttonNumber].transform.FindChild("Text").GetComponent<Text>().text == GetCorrectAnswer(Vocabularies[questionCounter]))
        {
            Debug.Log("Question correct");
            Buttons[buttonNumber].GetComponent<Image>().color = ColorCorrect;
        }
        else
        {
            Debug.Log("Wrong");
            Buttons[buttonNumber].GetComponent<Image>().color = ColorWrong;
        }
    }

    private void FillWords()
    {
        Vocabularies.Add(new Word("unravel", "çözmek"));
        Vocabularies.Add(new Word("mystery", "gizemli"));
        Vocabularies.Add(new Word("fever", "ateşi çıkmak"));
        Vocabularies.Add(new Word("profusely", "durmaksızın"));
        Vocabularies.Add(new Word("inevitebly", "değiştirilemez"));
        Vocabularies.Add(new Word("dispatch", "servis yönlendirme"));
        Vocabularies.Add(new Word("virologist", "virüs doktoru"));
        Vocabularies.Add(new Word("pecullar", "olağan dışı"));
        Vocabularies.Add(new Word("fascinated", "hayran olmak"));
        Vocabularies.Add(new Word("epidemic", "herkesi ilgilendiren"));
        Vocabularies.Add(new Word("transmit", "iletmek"));
        Vocabularies.Add(new Word("lethal", "ölümcül"));

        /**GOES ON WORDS**/
    }
}
