﻿/**
* Copyright 2015 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using UnityEngine;
using System.Collections;
using IBM.Watson.DeveloperCloud.Services.AlchemyLanguage.v1;
using IBM.Watson.DeveloperCloud.Logging;

public class ExampleAlchemyLanguage : MonoBehaviour {
    private AlchemyLanguage m_AlchemyLanguage = new AlchemyLanguage();
    private string m_ExampleURL_unitySDK = "https://developer.ibm.com/open/2016/01/21/introducing-watson-unity-sdk/";
    private string m_ExampleURL_watsonJeopardy = "http://www.nytimes.com/2011/02/17/science/17jeopardy-watson.html";
    private string m_ExampleURL_microformats = "http://microformats.org/wiki/hcard";
    private string m_ExampleText_unitySDK = "Game on! Introducing Watson Unity SDK, \nRICHARD LYLE  / JANUARY 21, 2016 \nAfter several months of work we are happy to present the Watson Unity SDK, an SDK to enable the Unity community to access the Watson Developer Cloud and build a cognitive application in Unity.\n\nI’ve been involved in the game industry for 22+ years now, but I can tell you in all honestly working in the Watson Innovation Labs and on this project has been the highlight of my career. This SDK really represents the first phase in what we plan to bring to the community, which in the end will be a framework for building a full cognitive application.\n\nYou as a developer will find very simple C# service abstractions for accessing Dialog, Speech To Text, Text to Speech, Language Translation, and Natural Language Classification services. Additionally, we’ve implemented something we are calling a Widget, which has inputs and outputs and performs some basic function.\n\nThese widgets can be connected together to form a graph for the data that’s routed for a given cognitive application. The widgets will attempt to automatically connect to each other, or you as a developer can override that behavior and manually take control of the process. We’ve implemented widgets for all of the basic services and provide a couple of example applications showing how they can work together.\n\nWe plan to continue to expand and build on the Watson Unity SDK. We invite you to join us in contributing to and using the SDK, or by simply giving us your feedback. We’d love to have you on board for this ride!";
    private string m_ExampleText_watsonJeopardy = "Computer Wins on 'Jeopardy!': Trivial, It's Not\nBy JOHN MARKOFF\nYORKTOWN HEIGHTS, N.Y. — In the end, the humans on \"Jeopardy!\" surrendered meekly.\n\nFacing certain defeat at the hands of a room-size I.B.M. computer on Wednesday evening, Ken Jennings, famous for winning 74 games in a row on the TV quiz show, acknowledged the obvious. \"I, for one, welcome our new computer overlords,\" he wrote on his video screen, borrowing a line from a \"Simpsons\" episode.\n\nFrom now on, if the answer is \"the computer champion on \"Jeopardy!,\" the question will be, \"What is Watson?\"\n\nFor I.B.M., the showdown was not merely a well-publicized stunt and a $1 million prize, but proof that the company has taken a big step toward a world in which intelligent machines will understand and respond to humans, and perhaps inevitably, replace some of them.\n\nWatson, specifically, is a \"question answering machine\" of a type that artificial intelligence researchers have struggled with for decades — a computer akin to the one on \"Star Trek\" that can understand questions posed in natural language and answer them.\n\nWatson showed itself to be imperfect, but researchers at I.B.M. and other companies are already developing uses for Watson's technologies that could have a significant impact on the way doctors practice and consumers buy products.\n\n\"Cast your mind back 20 years and who would have thought this was possible?\" said Edward Feigenbaum, a Stanford University computer scientist and a pioneer in the field.\n\nIn its \"Jeopardy!\" project, I.B.M. researchers were tackling a game that requires not only encyclopedic recall, but also the ability to untangle convoluted and often opaque statements, a modicum of luck, and quick, strategic button pressing.\n\nThe contest, which was taped in January here at the company's T. J. Watson Research Laboratory before an audience of I.B.M. executives and company clients, played out in three televised episodes concluding Wednesday. At the end of the first day, Watson was in a tie with Brad Rutter, another ace human player, at $5,000 each, with Mr. Jennings trailing with $2,000.\n\nBut on the second day, Watson went on a tear. By night's end, Watson had a commanding lead with a total of $35,734, compared with Mr. Rutter's $10,400 and Mr. Jennings's $4,800.\n\nVictory was not cemented until late in the third match, when Watson was in Nonfiction. \"Same category for $1,200,\" it said in a manufactured tenor, and lucked into a Daily Double. Mr. Jennings grimaced.\n\nEven later in the match, however, had Mr. Jennings won another key Daily Double it might have come down to Final Jeopardy, I.B.M. researchers acknowledged.\n\nThe final tally was $77,147 to Mr. Jennings's $24,000 and Mr. Rutter's $21,600.\n\nMore than anything, the contest was a vindication for the academic field of artificial intelligence, which began with great promise in the 1960s with the vision of creating a thinking machine and which became the laughingstock of Silicon Valley in the 1980s, when a series of heavily financed start-up companies went bankrupt.\n\nDespite its intellectual prowess, Watson was by no means omniscient. On Tuesday evening during Final Jeopardy, the category was U.S. Cities and the clue was: \"Its largest airport is named for a World War II hero; its second largest for a World War II battle.\"\n\nWatson drew guffaws from many in the television audience when it responded \"What is Toronto?????\"\n\nThe string of question marks indicated that the system had very low confidence in its response, I.B.M. researchers said, but because it was Final Jeopardy, it was forced to give a response. The machine did not suffer much damage. It had wagered just $947 on its result. (The correct answer is, \"What is Chicago?\")\n\n\"We failed to deeply understand what was going on there,\" said David Ferrucci, an I.B.M. researcher who led the development of Watson. \"The reality is that there's lots of data where the title is U.S. cities and the answers are countries, European cities, people, mayors. Even though it says U.S. cities, we had very little confidence that that's the distinguishing feature.\"\n\nThe researchers also acknowledged that the machine had benefited from the \"buzzer factor.\"\n\nBoth Mr. Jennings and Mr. Rutter are accomplished at anticipating the light that signals it is possible to \"buzz in,\" and can sometimes get in with virtually zero lag time. The danger is to buzz too early, in which case the contestant is penalized and \"locked out\" for roughly a quarter of a second.\n\nWatson, on the other hand, does not anticipate the light, but has a weighted scheme that allows it, when it is highly confident, to hit the buzzer in as little as 10 milliseconds, making it very hard for humans to beat. When it was less confident, it took longer to  buzz in. In the second round, Watson beat the others to the buzzer in 24 out of 30 Double Jeopardy questions.\n\n\"It sort of wants to get beaten when it doesn't have high confidence,\" Dr. Ferrucci said. \"It doesn't want to look stupid.\"\n\nBoth human players said that Watson's button pushing skill was not necessarily an unfair advantage. \"I beat Watson a couple of times,\" Mr. Rutter said.\n\nWhen Watson did buzz in, it made the most of it. Showing the ability to parse language, it responded to, \"A recent best seller by Muriel Barbery is called 'This of the Hedgehog,' \" with \"What is Elegance?\"\n\nIt showed its facility with medical diagnosis. With the answer: \"You just need a nap. You don't have this sleep disorder that can make sufferers nod off while standing up,\" Watson replied, \"What is narcolepsy?\"\n\nThe coup de grâce came with the answer, \"William Wilkenson's 'An Account of the Principalities of Wallachia and Moldavia' inspired this author's most famous novel.\" Mr. Jennings wrote, correctly, Bram Stoker, but realized that he could not catch up with Watson's winnings and wrote out his surrender.\n\nBoth players took the contest and its outcome philosophically.\n\n\"I had a great time and I would do it again in a heartbeat,\" said Mr. Jennings. \"It's not about the results; this is about being part of the future.\"\n\nFor I.B.M., the future will happen very quickly, company executives said. On Thursday it plans to announce that it will collaborate with Columbia University and the University of Maryland to create a physician's assistant service that will allow doctors to query a cybernetic assistant. The company also plans to work with Nuance Communications Inc. to add voice recognition to the physician's assistant, possibly making the service available in as little as 18 months.\n\n\"I have been in medical education for 40 years and we're still a very memory-based curriculum,\" said Dr. Herbert Chase, a professor of clinical medicine at Columbia University who is working with I.B.M. on the physician's assistant. \"The power of Watson- like tools will cause us to reconsider what it is we want students to do.\"\n\nI.B.M. executives also said they are in discussions with a major consumer electronics retailer to develop a version of Watson, named after I.B.M.'s founder, Thomas J. Watson, that would be able to interact with consumers on a variety of subjects like buying decisions and technical support.\n\nDr. Ferrucci sees none of the fears that have been expressed by theorists and science fiction writers about the potential of computers to usurp humans.\n\n\"People ask me if this is HAL,\" he said, referring to the computer in \"2001: A Space Odyssey.\" \"HAL's not the focus; the focus is on the computer on 'Star Trek,' where you have this intelligent information seek dialogue, where you can ask follow-up questions and the computer can look at all the evidence and tries to ask follow-up questions. That's very cool.\"\n\nThis article has been revised to reflect the following correction:\n\nCorrection: February 24, 2011\n\n\nAn article last Thursday about the I.B.M. computer Watson misidentified the academic field vindicated by Watson's besting of two human opponents on \"Jeopardy!\" It is artificial intelligence — not computer science, a broader field that includes artificial intelligence.";
	void Start () {
        LogSystem.InstallDefaultReactors();
        string unitySDK_release_html = Application.dataPath + "/Watson/Examples/ServiceExamples/TestData/unitySDK_release.html";
        string watson_beats_jeopardy_html = Application.dataPath + "/Watson/Examples/ServiceExamples/TestData/watson_beats_jeopardy.html";

        //  Get Author URL POST
//        if(!m_AlchemyLanguage.GetAuthors(OnGetAuthors, m_ExampleURL_unitySDK, true))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get authors URL POST!");

        //  Get Author URL GET
//        if(!m_AlchemyLanguage.GetAuthors(OnGetAuthors, m_ExampleURL_unitySDK))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get authors URL GET!");

        //  Get Author HTML POST
//        if(!m_AlchemyLanguage.GetAuthors(exampleHTMLPath, OnGetAuthors, m_ExampleURL_unitySDK))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get authors HTML POST!");

        //  Get Concepts URL GET
//        if(!m_AlchemyLanguage.GetRankedConceptsURL(OnGetConcepts, m_ExampleURL_unitySDK))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get concepts URL GET!");

        //  Get Concepts Text POST
//        if(!m_AlchemyLanguage.GetRankedConceptsText(OnGetConcepts, m_ExampleText_unitySDK, m_ExampleURL_unitySDK))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get concepts Text POST!");

        //  Get Concepts HTML POST
//        if(!m_AlchemyLanguage.GetRankedConceptsHTML(OnGetConcepts, exampleHTMLPath, m_ExampleURL))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get concepts HTML POST!");

        //  Get Date URL POST
//        if(!m_AlchemyLanguage.GetDatesURL(OnGetDates, m_ExampleURL_watsonJeopardy, null, true))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get dates by URL POST");

        //  Get Date Text POST
//        if(!m_AlchemyLanguage.GetDatesText(OnGetDates, m_ExampleText_watsonJeopardy, null, true))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get dates by text POST");

        //  Get Date HTML POST
//        if(!m_AlchemyLanguage.GetDatesHTML(OnGetDates, watson_beats_jeopardy_html, null, true))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get dates by HTML POST");

        //  Get Emotions URL POST
//        if(!m_AlchemyLanguage.GetEmotions(OnGetEmotions, m_ExampleURL_watsonJeopardy, true))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get emotions by URL POST");

        //  Get Emotions Text POST
//        if(!m_AlchemyLanguage.GetEmotions(OnGetEmotions, m_ExampleText_watsonJeopardy, true))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get emotions by text POST");

        //  Get Emotions HTML POST
//        if(!m_AlchemyLanguage.GetEmotions(OnGetEmotions, watson_beats_jeopardy_html, true))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get emotions by HTML POST");

        //  Extract Entities URL POST
//        if(!m_AlchemyLanguage.ExtractEntities(OnExtractEntities, m_ExampleURL_watsonJeopardy))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get entities by URL POST");

        //  Extract Entities Text POST
//        if(!m_AlchemyLanguage.ExtractEntities(OnExtractEntities, m_ExampleText_watsonJeopardy))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get entities by text POST");

        //  Extract Entities HTML POST
//        if(!m_AlchemyLanguage.ExtractEntities(OnExtractEntities, watson_beats_jeopardy_html))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get entities by HTML POST");

        //  Detect Feeds URL POST
//        if(!m_AlchemyLanguage.DetectFeeds(OnDetectFeeds, "http://www.kotaku.com"))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get feeds by URL POST");

        //  Extract Keywords URL POST
//        if(!m_AlchemyLanguage.ExtractKeywords(OnExtractKeywords, m_ExampleURL_watsonJeopardy))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get keywords by URL POST");

        //  Extract Keywords Text POST
//        if(!m_AlchemyLanguage.ExtractKeywords(OnExtractKeywords, m_ExampleText_watsonJeopardy))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get keywords by text POST");

        //  Extract Keywords HTML POST
//        if(!m_AlchemyLanguage.ExtractKeywords(OnExtractKeywords, watson_beats_jeopardy_html))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get keywords by HTML POST");

        //  Extract Languages URL POST
//        if(!m_AlchemyLanguage.GetLanguages(OnGetLanguages, m_ExampleURL_watsonJeopardy))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get languages by text POST");

        //  Extract Languages Text POST
//        if(!m_AlchemyLanguage.GetLanguages(OnGetLanguages, m_ExampleText_watsonJeopardy))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get languages by text POST");

        //  Extract Languages HTML POST
//        if(!m_AlchemyLanguage.GetLanguages(OnGetLanguages, watson_beats_jeopardy_html))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get languages by HTML POST");

        //  Get Microformats URL POST
//        if(!m_AlchemyLanguage.GetMicroformats(OnGetMicroformats, m_ExampleURL_microformats))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get microformats by text POST");

        //  Get Microformats HTML POST
////        if(!m_AlchemyLanguage.GetMicroformats(OnGetMicroformats, microformats_html))
////            Log.Debug("ExampleAlchemyLanguage", "Failed to get microformats by text POST");

        //  Get PublicationDate URL POST
//        if(!m_AlchemyLanguage.GetPublicationDate(OnGetPublicationDate, m_ExampleURL_watsonJeopardy))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get publication dates by text POST");

        //  Get Relations URL POST
//        if(!m_AlchemyLanguage.GetRelations(OnGetRelations, m_ExampleURL_watsonJeopardy))
//                Log.Debug("ExampleAlchemyLanguage", "Failed to get relations by text POST");

        //  Get Relations Text POST
//        if(!m_AlchemyLanguage.GetRelations(OnGetRelations, m_ExampleText_watsonJeopardy))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get relations by text POST");

        //  Get Relations HTML POST
//        if(!m_AlchemyLanguage.GetRelations(OnGetRelations, watson_beats_jeopardy_html))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get relations by HTML POST");

        //  Get Sentiment URL POST
//        if(!m_AlchemyLanguage.GetTextSentiment(OnGetTextSentiment, m_ExampleURL_watsonJeopardy))
//                    Log.Debug("ExampleAlchemyLanguage", "Failed to get sentiment by text POST");

        //  Get Sentiment Text POST
//        if(!m_AlchemyLanguage.GetTextSentiment(OnGetTextSentiment, m_ExampleText_watsonJeopardy))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get sentiment by text POST");

        //  Get Sentiment HTML POST
//        if(!m_AlchemyLanguage.GetTextSentiment(OnGetTextSentiment, watson_beats_jeopardy_html))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get sentiment by HTML POST");

        //  Get Sentiment URL POST
//        if(!m_AlchemyLanguage.GetTargetedSentiment(OnGetTargetedSentiment, m_ExampleURL_watsonJeopardy, "Jeopardy|Jennings|Watson"))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get targeted sentiment by text POST");

        //  Get Sentiment Text POST
//        if(!m_AlchemyLanguage.GetTargetedSentiment(OnGetTargetedSentiment, m_ExampleText_watsonJeopardy, "Jeopardy|Jennings|Watson"))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get targeted sentiment by text POST");

        //  Get Sentiment HTML POST
//        if(!m_AlchemyLanguage.GetTargetedSentiment(OnGetTargetedSentiment, watson_beats_jeopardy_html, "Jeopardy|Jennings|Watson"))
//            Log.Debug("ExampleAlchemyLanguage", "Failed to get targeted sentiment by HTML POST");
	}
	
    private void OnGetAuthors(AuthorsData authors, string data)
    {
        if(authors != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "data: {0}", data);
            if(authors.authors.names.Length == 0)
                Log.Debug("ExampleAlchemyLanguage", "No authors found!");

            foreach(string name in authors.authors.names)
                Log.Debug("ExampleAlchemyLanguage", "Author " + name + " found!");
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Author!");
        }
    }

    private void OnGetConcepts(ConceptsData concepts, string data)
    {
        if(concepts != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "status: {0}", concepts.status);
            Log.Debug("ExampleAlchemyLanguage", "url: {0}", concepts.url);
            Log.Debug("ExampleAlchemyLanguage", "language: {0}", concepts.language);
            if(concepts.concepts.Length == 0)
                Log.Debug("ExampleAlchemyLanguage", "No concepts found!");

            foreach(Concept concept in concepts.concepts)
                Log.Debug("ExampleAlchemyLanguage", "Concept: {0}, Relevance: {1}", concept.text, concept.relevance);
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Concepts!");
        }
    }

    private void OnGetDates(DateData dates, string data)
    {
        if(dates != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "status: {0}", dates.status);
            Log.Debug("ExampleAlchemyLanguage", "language: {0}", dates.language);
            Log.Debug("ExampleAlchemyLanguage", "url: {0}", dates.url);
            if(dates.dates == null || dates.dates.Length == 0)
                Log.Debug("ExampleAlchemyLanguage", "No dates found!");
            else
                foreach(Date date in dates.dates)
                    Log.Debug("ExampleAlchemyLanguage", "Text: {0}, Date: {1}", date.text, date.date);
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Dates!");
        }
    }

    private void OnGetEmotions(EmotionData emotions, string data)
    {
        if(emotions != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "status: {0}", emotions.status);
            Log.Debug("ExampleAlchemyLanguage", "url: {0}", emotions.url);
            Log.Debug("ExampleAlchemyLanguage", "language: {0}", emotions.language);
            Log.Debug("ExampleAlchemyLanguage", "text: {0}", emotions.text);
            if(emotions.docEmotions == null)
                Log.Debug("ExampleAlchemyLanguage", "No emotions found!");
            else
            {
                Log.Debug("ExampleAlchemyLanguage", "anger: {0}", emotions.docEmotions.anger);
                Log.Debug("ExampleAlchemyLanguage", "disgust: {0}", emotions.docEmotions.disgust);
                Log.Debug("ExampleAlchemyLanguage", "fear: {0}", emotions.docEmotions.fear);
                Log.Debug("ExampleAlchemyLanguage", "joy: {0}", emotions.docEmotions.joy);
                Log.Debug("ExampleAlchemyLanguage", "sadness: {0}", emotions.docEmotions.sadness);
            }
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Emotions!");
        }
    }

    private void OnExtractEntities(EntityData entityData, string data)
    {
        if(entityData != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "status: {0}", entityData.status);
            Log.Debug("ExampleAlchemyLanguage", "url: {0}", entityData.url);
            Log.Debug("ExampleAlchemyLanguage", "language: {0}", entityData.language);
            Log.Debug("ExampleAlchemyLanguage", "text: {0}", entityData.text);
            if(entityData == null || entityData.entities.Length == 0)
                Log.Debug("ExampleAlchemyLanguage", "No entities found!");
            else
                foreach(Entity entity in entityData.entities)
                    Log.Debug("ExampleAlchemyLanguage", "text: {0}, type: {1}", entity.text, entity.type);
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Emotions!");
        }
    }

    private void OnDetectFeeds(FeedData feedData, string data)
    {
        if(feedData != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "status: {0}", feedData.status);
            if(feedData == null || feedData.feeds.Length == 0)
                Log.Debug("ExampleAlchemyLanguage", "No feeds found!");
            else
                foreach(Feed feed in feedData.feeds)
                    Log.Debug("ExampleAlchemyLanguage", "text: {0}", feed.feed);
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Feeds!");
        }
    }

    private void OnExtractKeywords(KeywordData keywordData, string data)
    {
        if(keywordData != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "status: {0}", keywordData.status);
            Log.Debug("ExampleAlchemyLanguage", "url: {0}", keywordData.url);
            Log.Debug("ExampleAlchemyLanguage", "language: {0}", keywordData.language);
            Log.Debug("ExampleAlchemyLanguage", "text: {0}", keywordData.text);
            if(keywordData == null || keywordData.keywords.Length == 0)
                Log.Debug("ExampleAlchemyLanguage", "No keywords found!");
            else
                foreach(Keyword keyword in keywordData.keywords)
                    Log.Debug("ExampleAlchemyLanguage", "text: {0}, relevance: {1}", keyword.text, keyword.relevance);
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Keywords!");
        }
    }

    private void OnGetLanguages(LanguageData languages, string data)
    {
        if(languages != null)
        {
            if(string.IsNullOrEmpty(languages.language))
                Log.Debug("ExampleAlchemyLanguage", "No languages detected!");
            else
            {
                Log.Debug("ExampleAlchemyLanguage", "status: {0}", languages.status);
                Log.Debug("ExampleAlchemyLanguage", "url: {0}", languages.url);
                Log.Debug("ExampleAlchemyLanguage", "language: {0}", languages.language);
                Log.Debug("ExampleAlchemyLanguage", "ethnologue: {0}", languages.ethnologue);
                Log.Debug("ExampleAlchemyLanguage", "iso_639_1: {0}", languages.iso_639_1);
                Log.Debug("ExampleAlchemyLanguage", "iso_639_2: {0}", languages.iso_639_2);
                Log.Debug("ExampleAlchemyLanguage", "iso_639_3: {0}", languages.iso_639_3);
                Log.Debug("ExampleAlchemyLanguage", "native_speakers: {0}", languages.native_speakers);
                Log.Debug("ExampleAlchemyLanguage", "wikipedia: {0}", languages.wikipedia);
            }
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Dates!");
        }
    }

    private void OnGetMicroformats(MicroformatData microformats, string data)
    {
        if(microformats != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "status: {0}", microformats.status);
            Log.Debug("ExampleAlchemyLanguage", "url: {0}", microformats.url);
            if(microformats.microformats.Length == 0)
                Log.Warning("ExampleAlchemyLanguage", "No microformats found!");
            else
            {
                foreach(Microformat microformat in microformats.microformats)
                    Log.Debug("ExampleAlchemyLanguage", "field: {0}, data: {1}.", microformat.field, microformat.data);
            }
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Microformats!");
        }
    }

    private void OnGetPublicationDate(PubDateData pubDates, string data)
    {
        if(pubDates != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "status: {0}", pubDates.status);
            Log.Debug("ExampleAlchemyLanguage", "url: {0}", pubDates.url);
            Log.Debug("ExampleAlchemyLanguage", "language: {0}", pubDates.language);
            if(pubDates.publicationDate != null)
                Log.Debug("ExampleAlchemyLanguage", "date: {0}, confident: {1}", pubDates.publicationDate.date, pubDates.publicationDate.confident);
            else
                Log.Debug("ExampleAlchemyLanguage", "Failed to find Publication Dates!");
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Publication Dates!");
        }
    }

    private void OnGetRelations(RelationsData relationsData, string data)
    {
        if(relationsData != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "status: {0}", relationsData.status);
            Log.Debug("ExampleAlchemyLanguage", "url: {0}", relationsData.url);
            Log.Debug("ExampleAlchemyLanguage", "language: {0}", relationsData.language);
            Log.Debug("ExampleAlchemyLanguage", "text: {0}", relationsData.text);
            if(relationsData.relations == null || relationsData.relations.Length == 0)
                Log.Debug("ExampleAlchemyLanguage", "No relations found!");
            else
                foreach(Relation relation in relationsData.relations)
                    if(relation.subject != null && !string.IsNullOrEmpty(relation.subject.text))
                        Log.Debug("ExampleAlchemyLanguage", "Text: {0}, Date: {1}", relation.sentence, relation.subject.text);
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Relations!");
        }
    }

    private void OnGetTextSentiment(SentimentData sentimentData, string data)
    {
        if(sentimentData != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "status: {0}", sentimentData.status);
            Log.Debug("ExampleAlchemyLanguage", "url: {0}", sentimentData.url);
            Log.Debug("ExampleAlchemyLanguage", "language: {0}", sentimentData.language);
            Log.Debug("ExampleAlchemyLanguage", "text: {0}", sentimentData.text);
            if(sentimentData.docSentiment == null)
                Log.Debug("ExampleAlchemyLanguage", "No sentiment found!");
            else
                if(sentimentData.docSentiment != null && !string.IsNullOrEmpty(sentimentData.docSentiment.type))
                    Log.Debug("ExampleAlchemyLanguage", "Sentiment: {0}, Score: {1}", sentimentData.docSentiment.type, sentimentData.docSentiment.score);
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Relations!");
        }
    }

    private void OnGetTargetedSentiment(TargetedSentimentData sentimentData, string data)
    {
        if(sentimentData != null)
        {
            Log.Debug("ExampleAlchemyLanguage", "status: {0}", sentimentData.status);
            Log.Debug("ExampleAlchemyLanguage", "url: {0}", sentimentData.url);
            Log.Debug("ExampleAlchemyLanguage", "language: {0}", sentimentData.language);
            Log.Debug("ExampleAlchemyLanguage", "text: {0}", sentimentData.text);
            if(sentimentData.results == null)
                Log.Debug("ExampleAlchemyLanguage", "No sentiment found!");
            else
                if(sentimentData.results == null || sentimentData.results.Length == 0)
                    Log.Warning("ExampleAlchemyLanguage", "No sentiment results!");
                else
                    foreach(TargetedSentiment result in sentimentData.results)
                        Log.Debug("ExampleAlchemyLanguage", "text: {0}, sentiment: {1}, score: {2}", result.text, result.sentiment.score, result.sentiment.type);
        }
        else
        {
            Log.Debug("ExampleAlchemyLanguage", "Failed to find Relations!");
        }
    }
}
