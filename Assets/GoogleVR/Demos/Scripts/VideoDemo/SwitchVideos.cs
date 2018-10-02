// Copyright (C) 2016 Google Inc. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//    limitations under the License.

namespace GoogleVR.VideoDemo {
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public class SwitchVideos : MonoBehaviour {

        // Frames
        public GameObject frameOne;
        public GameObject frameTwo;
        public GameObject frameThree;
        public GameObject frameFour;
        public GameObject frameFive;

        // Pictures
        public Material pictureOneFrameOne;
        public Material pictureTwoFrameOne;
        public Material pictureThreeFrameOne;
        public Material pictureFourFrameOne;
        public Material pictureFiveFrameOne;

        public Material pictureOneFrameTwo;
        public Material pictureTwoFrameTwo;
        public Material pictureThreeFrameTwo;
        public Material pictureFourFrameTwo;
        public Material pictureFiveFrameTwo;

        public Material pictureOneFrameThree;
        public Material pictureTwoFrameThree;
        public Material pictureThreeFrameThree;
        public Material pictureFourFrameThree;
        public Material pictureFiveFrameThree;

        public Material pictureOneFrameFour;
        public Material pictureTwoFrameFour;
        public Material pictureThreeFrameFour;
        public Material pictureFourFrameFour;
        public Material pictureFiveFrameFour;

        public Material pictureOneFrameFive;
        public Material pictureTwoFrameFive;
        public Material pictureThreeFrameFive;
        public Material pictureFourFrameFive;
        public Material pictureFiveFrameFive;

        // Audio
        public AudioClip intro;
        public AudioClip rightAnswer;
        public AudioClip wrongAnswer;
        public AudioClip conclusion;

        public AudioClip firstQuestion;
        public AudioClip firstResponse;
        public AudioClip secondQuestion;
        public AudioClip secondResponse;
        public AudioClip thirdQuestion;
        public AudioClip thirdResponse;
        public AudioClip fourthQuestion;
        public AudioClip fourthResponse;
        public AudioClip fifthQuestion;
        public AudioClip fifthResponse;

        // Text
        private readonly string phraseTextStart = "Welcome to the Game Show!";
        private readonly string topTextStart = "";
        private readonly string midTextStart = "";
        private readonly string botTextStart = "Start";

        private readonly string phraseTextOne = "How much food is wasted in the US?";
        private readonly string topTextOne = "10-20%";
        private readonly string midTextOne = "20-30%";
        private readonly string botTextOne = "30-40%";

        private readonly string phraseTextTwo = "Where is most edible food thrown out?";
        private readonly string topTextTwo = "Farms";
        private readonly string midTextTwo = "Retailers";
        private readonly string botTextTwo = "Homes";

        private readonly string phraseTextThree = "Why is this food thrown out?";
        private readonly string topTextThree = "Tastes bad";
        private readonly string midTextThree = "Looks different";
        private readonly string botTextThree = "Unhealthy to eat";

        private readonly string phraseTextFour = "Expiration dates are?";
        private readonly string topTextFour = "Just suggestion";
        private readonly string midTextFour = "Government mandated";
        private readonly string botTextFour = "Accurate";

        private readonly string phraseTextFive = "Could you be sued for donating bad food?";
        private readonly string topTextFive = "Yes";
        private readonly string midTextFive = "No";
        private readonly string botTextFive = "Only in some states";

        // Collections
        private GameObject[] frames;
        private Material[] picturesFrameOne;
        private Material[] picturesFrameTwo;
        private Material[] picturesFrameThree;
        private Material[] picturesFrameFour;
        private Material[] picturesFrameFive;
        private Material[][] pictures;

        private string[] phraseText;
        private string[] topText;
        private string[] midText;
        private string[] botText;

        private Text titlePhraseText;
        private Text topButtonText;
        private Text midButtonText;
        private Text botButtonText;

        private AudioClip[] responses;
        private AudioClip[] questions;

        // Buttons
        private Button topButton;
        private Button midButton;
        private Button botButton;

        // Script values
        private int score;
        private int questionCounter;
        private readonly int[] answers = {2,0,1,0,1};
        private AudioClip result;
        private AudioClip responeNarration;
        private AudioClip questionNarration;
        private bool isDone;

        public void Awake()
        {
            // Assign values
            titlePhraseText = gameObject.transform.Find("TitlePhrase").gameObject.GetComponentInChildren<Text>();
            topButtonText = gameObject.transform.Find("TopButton").gameObject.GetComponentInChildren<Text>();
            midButtonText = gameObject.transform.Find("MidButton").gameObject.GetComponentInChildren<Text>();
            botButtonText = gameObject.transform.Find("BotButton").gameObject.GetComponentInChildren<Text>();

            topButton = gameObject.transform.Find("TopButton").gameObject.GetComponentInChildren<Button>();
            midButton = gameObject.transform.Find("MidButton").gameObject.GetComponentInChildren<Button>();
            botButton = gameObject.transform.Find("BotButton").gameObject.GetComponentInChildren<Button>();

            // Collect values
            frames = new GameObject[5];
            frames[0] = frameOne;
            frames[1] = frameTwo;
            frames[2] = frameThree;
            frames[3] = frameFour;
            frames[4] = frameFive;

            picturesFrameOne = new Material[5];
            picturesFrameOne[0] = pictureOneFrameOne;
            picturesFrameOne[1] = pictureTwoFrameOne;
            picturesFrameOne[2] = pictureThreeFrameOne;
            picturesFrameOne[3] = pictureFourFrameOne;
            picturesFrameOne[4] = pictureFiveFrameOne;

            picturesFrameTwo = new Material[5];
            picturesFrameTwo[0] = pictureOneFrameTwo;
            picturesFrameTwo[1] = pictureTwoFrameTwo;
            picturesFrameTwo[2] = pictureThreeFrameTwo;
            picturesFrameTwo[3] = pictureFourFrameTwo;
            picturesFrameTwo[4] = pictureFiveFrameTwo;

            picturesFrameThree = new Material[5];
            picturesFrameThree[0] = pictureOneFrameThree;
            picturesFrameThree[1] = pictureTwoFrameThree;
            picturesFrameThree[2] = pictureThreeFrameThree;
            picturesFrameThree[3] = pictureFourFrameThree;
            picturesFrameThree[4] = pictureFiveFrameThree;

            picturesFrameFour = new Material[5];
            picturesFrameFour[0] = pictureOneFrameFour;
            picturesFrameFour[1] = pictureTwoFrameFour;
            picturesFrameFour[2] = pictureThreeFrameFour;
            picturesFrameFour[3] = pictureFourFrameFour;
            picturesFrameFour[4] = pictureFiveFrameFour;

            picturesFrameFive = new Material[5];
            picturesFrameFive[0] = pictureOneFrameFive;
            picturesFrameFive[1] = pictureTwoFrameFive;
            picturesFrameFive[2] = pictureThreeFrameFive;
            picturesFrameFive[3] = pictureFourFrameFive;
            picturesFrameFive[4] = pictureFiveFrameFive;

            pictures = new Material[5][];
            pictures[0] = picturesFrameOne;
            pictures[1] = picturesFrameTwo;
            pictures[2] = picturesFrameThree;
            pictures[3] = picturesFrameFour;
            pictures[4] = picturesFrameFive;

            phraseText = new string[5];
            phraseText[0] = phraseTextOne;
            phraseText[1] = phraseTextTwo;
            phraseText[2] = phraseTextThree;
            phraseText[3] = phraseTextFour;
            phraseText[4] = phraseTextFive;

            topText = new string[5];
            topText[0] = topTextOne;
            topText[1] = topTextTwo;
            topText[2] = topTextThree;
            topText[3] = topTextFour;
            topText[4] = topTextFive;

            midText = new string[5];
            midText[0] = midTextOne;
            midText[1] = midTextTwo;
            midText[2] = midTextThree;
            midText[3] = midTextFour;
            midText[4] = midTextFive;

            botText = new string[5];
            botText[0] = botTextOne;
            botText[1] = botTextTwo;
            botText[2] = botTextThree;
            botText[3] = botTextFour;
            botText[4] = botTextFive;

            responses = new AudioClip[5];
            responses[0] = firstResponse;
            responses[1] = secondResponse;
            responses[2] = thirdResponse;
            responses[3] = fourthResponse;
            responses[4] = fifthResponse;

            questions = new AudioClip[5];
            questions[0] = firstQuestion;
            questions[1] = secondQuestion;
            questions[2] = thirdQuestion;
            questions[3] = fourthQuestion;
            questions[4] = fifthQuestion;

            // Intialize values
            titlePhraseText.text = phraseTextStart;
            topButtonText.text = topTextStart;
            midButtonText.text = midTextStart;
            botButtonText.text = botTextStart;

            topButton.interactable = false;
            midButton.interactable = false;

            score = 0;
            questionCounter = -1;
            isDone = false;

            Debug.Log("End inti " + questionCounter);

            // Play sound
            PlaySoundWithCallback(intro, JustWait);
        }

        public void TopButton()
        {
            Response(0);
        }

        public void MidButton()
        {
            Response(1);
        }

        public void BotButton()
        {
            Response(2);
        }

        // Once audio finished, the callback
        public delegate void AudioCallback();

        private void JustWait()
        {

        }

        public void PlaySoundWithCallback(AudioClip clip, AudioCallback callback)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
            StartCoroutine(DelayedCallback(clip.length, callback));
        }

        private IEnumerator DelayedCallback(float time, AudioCallback callback)
        {
            yield return new WaitForSeconds(time);
            callback();
        }

        private void Response(int buttonPress)
        {
            if (questionCounter == answers.Length)
            {
                return;
            }
            else if (questionCounter == -1)
            {
                Debug.Log("Start response" + questionCounter);
                // Start questions
                ++questionCounter;
                Question();
                return;
            }
            else if (buttonPress == answers[questionCounter])
            {
                Debug.Log("Question Counter is " + questionCounter);
                // Question correct
                ++score;
                result = rightAnswer;
            }
            else
            {
                Debug.Log("Else " + questionCounter);
                // Question incorrect
                result = wrongAnswer;
            }

            Debug.Log("Other " + questionCounter);

            // Disable buttons
            topButton.interactable = false;
            midButton.interactable = false;
            botButton.interactable = false;

            // Show pictures
            for (int i = 0; i < frames.Length; i++)
            {
                Debug.Log("Show pictures " + i);
                frames[i].GetComponent<Renderer>().material = pictures[i][questionCounter];
                frames[i].GetComponent<MeshRenderer>().enabled = true;
            }

            // Play response audio
            PlaySoundWithCallback(result, JustWait);

            // Timer for next question
            PlaySoundWithCallback(responses[questionCounter], Question);

            ++questionCounter;
        }

        private void Question()
        {
            // Check if game is done
            if (isDone == true)
            {
                return;
            }

            // Check if out of questions
            if (questionCounter >= answers.Length)
            {
                Debug.Log("No more questions " + questionCounter);

                Conclusion();
                return;
            }

            // Hide pictures
            for (int i = 0; i < frames.Length; i++)
            {
                Debug.Log("Hide pictures " + i);
                frames[i].GetComponent<MeshRenderer>().enabled = false;
            }

            // Enable buttons
            topButton.interactable = true;
            midButton.interactable = true;
            botButton.interactable = true;

            // Change button text
            titlePhraseText.text = phraseText[questionCounter];
            topButtonText.text = topText[questionCounter];
            midButtonText.text = midText[questionCounter];
            botButtonText.text = botText[questionCounter];

            Debug.Log("Question end " + questionCounter);

            // Play audio
            PlaySoundWithCallback(questions[questionCounter], JustWait);
        }

        private void Conclusion()
        {
            // Show score
            Debug.Log("The score is " + score);
            titlePhraseText.text = "Score:";
            topButtonText.text = score.ToString();
            midButtonText.text = "out of";
            botButtonText.text = "5";

            // Play conclution
            PlaySoundWithCallback(conclusion, Petition);
        }

        private void Petition()
        {
            isDone = true;

            // Update petition text
            titlePhraseText.text = "Do you agree?";
            topButtonText.text = "";
            midButtonText.text = "Yes";
            botButtonText.text = "No";

            // Disable buttons
            topButton.interactable = true;
            midButton.interactable = true;
            botButton.interactable = true;
        }
    }
}
