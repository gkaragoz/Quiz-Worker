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
        Vocabularies.Add(new Word("outbreak", "bulaştırmak"));
        Vocabularies.Add(new Word("horrendous", "ürkütücü"));
        Vocabularies.Add(new Word("emidemiologist", "epidemiyoloji uzmanı"));
        Vocabularies.Add(new Word("landmark", "herkesin bildiği popüler bir şey"));
        Vocabularies.Add(new Word("plummet", "hızlıca düşmek"));
        Vocabularies.Add(new Word("arduous", "olması çok zor"));
        Vocabularies.Add(new Word("feasible", "makul"));
        Vocabularies.Add(new Word("strain", "ırk"));
        Vocabularies.Add(new Word("replicate", "tekrarlama"));
        Vocabularies.Add(new Word("invade", "akın etmek"));
        Vocabularies.Add(new Word("rainforcement", "takviye"));
        Vocabularies.Add(new Word("ambush", "pusu"));
        Vocabularies.Add(new Word("pharmaceutical", "ilaçlarla ilgili"));
        Vocabularies.Add(new Word("vaccine", "aşı"));
        Vocabularies.Add(new Word("quarantine", "karantina"));
        Vocabularies.Add(new Word("primate", "ilkel"));
        Vocabularies.Add(new Word("host", "ev sahipliği yapmak"));
        Vocabularies.Add(new Word("carcass", "leş"));
        Vocabularies.Add(new Word("impact", "darbe"));
        Vocabularies.Add(new Word("onslaught", "saldırı"));
        Vocabularies.Add(new Word("dawn", "gün ışıması"));
        Vocabularies.Add(new Word("offspring", "yavru, çocuk"));
        Vocabularies.Add(new Word("autopsy", "otopsi"));
        Vocabularies.Add(new Word("rodent", "kemirgen"));
        Vocabularies.Add(new Word("urbanzation", "kente göç"));
        Vocabularies.Add(new Word("mutation", "mutasyon"));
        Vocabularies.Add(new Word("wake up call", "kafaya dank etmek"));
        Vocabularies.Add(new Word("meddle", "karışmak"));
        Vocabularies.Add(new Word("mercy", "merhamet"));
        Vocabularies.Add(new Word("meticulousness", "titiz"));
        Vocabularies.Add(new Word("grab bag", "karman çorman"));
        Vocabularies.Add(new Word("devotees", "tasavvuf"));
        Vocabularies.Add(new Word("theologist", "ilahiyatçı"));
        Vocabularies.Add(new Word("cogy", "sinsi"));
        Vocabularies.Add(new Word("aminous", "uğursuz"));
        Vocabularies.Add(new Word("playball", "sürü psikolojisi"));
        Vocabularies.Add(new Word("bening", "zevk veren - zararsız şey"));
        Vocabularies.Add(new Word("jeopardy", "tehlike"));
        Vocabularies.Add(new Word("misrepresantation", "yanlış beyan"));
        Vocabularies.Add(new Word("precautions", "önlemler"));
        Vocabularies.Add(new Word("revolution", "vahiy"));
        Vocabularies.Add(new Word("substantiote", "kanıtlamak"));
        Vocabularies.Add(new Word("ginormous", "büyük, muazzam, çok büyük"));
        Vocabularies.Add(new Word("resolve", "çözümlemek"));
        Vocabularies.Add(new Word("empty handed", "eli boş kalmak"));
        Vocabularies.Add(new Word("spectacle", "değişik gösterim"));
        Vocabularies.Add(new Word("sugarcane", "şeker kamışı"));
        Vocabularies.Add(new Word("sugarmill", "şeker değirmeni"));
        Vocabularies.Add(new Word("efficient", "verimli, etkili"));
        Vocabularies.Add(new Word("extract", "ayrıştırmak, seçip çıkartmak"));
        Vocabularies.Add(new Word("fermantation", "fermantasyon"));
        Vocabularies.Add(new Word("yeast", "maya"));
        Vocabularies.Add(new Word("distill", "damıtmak"));
        Vocabularies.Add(new Word("renewable", "yenilenebilir"));
        Vocabularies.Add(new Word("boils down to", "indirgemek"));
        Vocabularies.Add(new Word("fore front", "ön taraf"));
        Vocabularies.Add(new Word("derive", "türemek"));
        Vocabularies.Add(new Word("composition", "kompozisyon"));
        Vocabularies.Add(new Word("decade", "on yıl"));
        Vocabularies.Add(new Word("crop", "mahsul(noun), hasat(verb)"));
        Vocabularies.Add(new Word("synthetic", "sentetik"));
        Vocabularies.Add(new Word("blueprint", "şablon"));
        Vocabularies.Add(new Word("catalyst", "katalizör"));
        Vocabularies.Add(new Word("contain", "içermek"));
        Vocabularies.Add(new Word("infastructure", "alt yapı"));
        Vocabularies.Add(new Word("congested", "tıkanmış, tıkalı"));
        Vocabularies.Add(new Word("inefficiency", "işe yaramaz"));
        Vocabularies.Add(new Word("enormous", "büyük, muazzam"));
        Vocabularies.Add(new Word("commute", "ev iş arasındaki yol"));
        Vocabularies.Add(new Word("utilize", "değerlendirmek"));
        Vocabularies.Add(new Word("eliminate", "elemek"));
        Vocabularies.Add(new Word("merge", "birleştirmek"));
        Vocabularies.Add(new Word("density", "yoğunluk"));
        Vocabularies.Add(new Word("optimize", "en uygun hale getirmek"));
        Vocabularies.Add(new Word("tweak", "çimcik, keskin çekmek, uyarlamak"));
        Vocabularies.Add(new Word("take into", "consideration, dikkate almak"));
        Vocabularies.Add(new Word("autonomous", "özerk"));

        /**GOES ON WORDS**/
    }
}



