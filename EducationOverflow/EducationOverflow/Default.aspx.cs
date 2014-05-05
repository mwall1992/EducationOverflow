using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.IO.Compression;
using StackExchangeAPI;

namespace EducationOverflow {
    
    public partial class Default : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {

            /* Stack Exchange Sites */

            var siteQueryBuilder = new SiteAPIQueryBuilder().SetPage(new StackExchangeAPI.Page(3, 100)).SetFilter("!SlEEHh3j5jHHcKLso");
            IQuery<Site> siteQuery = siteQueryBuilder.GetQuery();

            //ResponseWrapper<Site> sites = StackExchangeAPIClient.GetResponse<Site>(siteQuery);
            
            //foreach (Site site in sites.Items) {
            //    Business.StackExchangeSite.InsertStackExchangeSite(site.ApiSiteParameter, site.Name, 0);
            //}

            /* Questions */

            //int currentQuestionCount = 0;
            //const int minQuestions = 50;
            //
            //int page = 1;
            //
            //do {
            //
            //    List<string> tags = new List<string>() { "C" };
            //    var questionQueryBuilder = new QuestionAPIQueryBuilder().SetPage(new StackExchangeAPI.Page(page++, 100)).SetTagNames(tags).SetSite("stackoverflow").SetFilter("!)5__yhx4AThgI5_6UUndqcI_8Jey");
            //
            //    IQuery<Question> questionQuery = questionQueryBuilder.GetQuery();
            //
            //    ResponseWrapper<Question> questions = StackExchangeAPIClient.GetResponse<Question>(questionQuery);
            //
            //    foreach (Question question in questions.Items) {
            //        if (question.IsAnswered) {
            //            currentQuestionCount++;
            //            Business.QuestionURL.InsertQuestionURL(question.QuestionId, "stackoverflow", question.Title, question.Url);
            //            Business.QuestionInfo.InsertQuestionInfo(question.Url, question.Body, question.UpVoteCount, question.DownVoteCount);
            //        }
            //    }
            //} while(currentQuestionCount < minQuestions);

            /* Answers */

            //List<DataObjects.Question> questionURLs = Business.QuestionURL.SelectQuestionURL();
            //
            //foreach (DataObjects.Question question in questionURLs) {
            //
            //    int apiQuestionId = question.ApiQuestionId;
            //
            //    var answersQueryBuilder = new AnswerAPIQueryBuilder()
            //    .SetPage(new StackExchangeAPI.Page(1, 100))
            //    .SetApiMethodExtension("answers")
            //    .SetMethodParameterValues(new List<string>() { string.Format("{0}", apiQuestionId) })
            //    .SetSite("stackoverflow")
            //    .SetAPIVersion("2.2/");
            //
            //    IQuery<Answer> answerQuery = answersQueryBuilder.GetQuery();
            //
            //    ResponseWrapper<Answer> answers = StackExchangeAPIClient.GetResponse<Answer>(answerQuery);
            //
            //    foreach (Answer answer in answers.Items) {
            //        Business.Answer.InsertAnswer(question.URL, answer.AnswerId, answer.Body, 
            //            answer.UpVoteCount, answer.DownVoteCount, answer.IsAccepted);
            //    }
            //
            //}

            //List<DataObjects.Answer> answers = Business.Answer.SelectAnswers();

            //List<string> answerIds = new List<string>();

            //foreach (DataObjects.Answer answer in answers) {
                
            //    if (answer.UpVotes == 6) {

            //    answerIds.Add(string.Format("{0}", answer.ApiAnswerId));
            //    if (answerIds.Count == 99) {

            //        var answerDetailsQueryBuilder = new AnswerAPIQueryBuilder()
            //.SetPage(new StackExchangeAPI.Page(1, 100))
            //.SetMethodParameterValues(answerIds)
            //.SetSite("stackoverflow")
            //.SetAPIVersion("2.2/")
            //.SetFilter("!Fcazzsr2b3M)8uCh14t7X2-jEL");

            //        IQuery<Answer> answerQuery = answerDetailsQueryBuilder.GetQuery();

            //        ResponseWrapper<Answer> queryResults = StackExchangeAPIClient.GetResponse<Answer>(answerQuery);

            //        foreach (Answer updatedAnswer in queryResults.Items) {

            //            foreach (DataObjects.Answer oldAnswer in answers) {

            //                if (updatedAnswer.AnswerId == oldAnswer.ApiAnswerId) {
            //                    Business.Answer.UpdateAnswer(oldAnswer.QuestionURL, 
            //                    oldAnswer.ApiAnswerId, updatedAnswer.Body, updatedAnswer.UpVoteCount,
            //                    updatedAnswer.DownVoteCount, updatedAnswer.IsAccepted, 
            //                    oldAnswer.QuestionURL, oldAnswer.ApiAnswerId);
            //                    break;
            //                }
            //            }
            //        }


            //        answerIds.Clear();
            //    }
            //    }

                
            //}

            //if (answerIds.Count > 0) {
            //    var answerDetailsQueryBuilder = new AnswerAPIQueryBuilder()
            //    .SetPage(new StackExchangeAPI.Page(1, 100))
            //    .SetMethodParameterValues(answerIds)
            //    .SetSite("stackoverflow")
            //    .SetAPIVersion("2.2/")
            //    .SetFilter("!Fcazzsr2b3M)8uCh14t7X2-jEL");

            //    IQuery<Answer> answerQuery = answerDetailsQueryBuilder.GetQuery();

            //    ResponseWrapper<Answer> queryResults = StackExchangeAPIClient.GetResponse<Answer>(answerQuery);

            //    foreach (Answer updatedAnswer in queryResults.Items) {

            //        foreach (DataObjects.Answer oldAnswer in answers) {

            //            if (updatedAnswer.AnswerId == oldAnswer.ApiAnswerId) {
            //                Business.Answer.UpdateAnswer(oldAnswer.QuestionURL,
            //                oldAnswer.ApiAnswerId, updatedAnswer.Body, updatedAnswer.UpVoteCount,
            //                updatedAnswer.DownVoteCount, updatedAnswer.IsAccepted,
            //                oldAnswer.QuestionURL, oldAnswer.ApiAnswerId);
            //                break;
            //            }
            //        }
            //    }


            //    answerIds.Clear();
            //}

            /* Tags and Tag Synonyms (doesn't include c# - error processing #) */

            //List<DataObjects.Question> questions = Business.QuestionURL.SelectQuestionURL();

            //List<string> questionIds = new List<string>();

            //// for each question retrieved from the education overflow db
            //foreach (DataObjects.Question question in questions) {

            //    questionIds.Add(string.Format("{0}", question.ApiQuestionId));
            //    if (questionIds.Count == 99 || question == questions[questions.Count - 1]) {

            //        // query stake exchange for the tags associated with the question
            //        var questionTagQueryBuilder = new QuestionAPIQueryBuilder()
            //        .SetPage(new StackExchangeAPI.Page(1, 100))
            //        .SetMethodParameterValues(questionIds)
            //        .SetSite("stackoverflow")
            //        .SetAPIVersion("2.2/")
            //        .SetFilter("!BHMIbze0B1Z1ROjg8q3_7M*uE5sbJt");

            //        IQuery<Question> questionTagQuery = questionTagQueryBuilder.GetQuery();

            //        ResponseWrapper<Question> queryResults = StackExchangeAPIClient.GetResponse<Question>(questionTagQuery);

            //        // collect all tags
            //        SortedSet<string> tags = new SortedSet<string>();
            //        foreach (Question retrievedQuestion in queryResults.Items) {
                        
            //            foreach (string tag in retrievedQuestion.Tags) {
                            
            //                if (tag != "c#" && tag != "C#") {

            //                tags.Add(tag);
            //                if (tags.Count == 99 
            //                        || tag == retrievedQuestion.Tags[retrievedQuestion.Tags.Length - 1]) {

            //                    List<string> searchedTags = new List<string>();
            //                    foreach (string searchTag in tags) {
            //                        searchedTags.Add(searchTag);
            //                    }

            //                    // query stack exchange for information about tags
            //                    ResponseWrapper<Tag> retrievedTags = null;

            //                    int pageNumber = 1;
            //                    do {

            //                        // retrieve tag information
            //                        var tagQueryBuilder = new TagAPIQueryBuilder()
            //                        .SetPage(new StackExchangeAPI.Page(pageNumber++, 100))
            //                        .SetMethodParameterValues(searchedTags)
            //                        .SetApiMethodExtension("info")
            //                        .SetSite("stackoverflow")
            //                        .SetAPIVersion("2.2/")
            //                        .SetFilter("!bNKX0p-tnVKW9D");

            //                        IQuery<Tag> tagQuery = tagQueryBuilder.GetQuery();

            //                        retrievedTags = StackExchangeAPIClient.GetResponse<Tag>(tagQuery);

            //                        // insert tag information into database (including synonyms)
            //                        foreach (Tag retrievedTag in retrievedTags.Items) {
            //                            Business.Tag.InsertTag(retrievedTag.Name, "", retrievedTag.Count);

            //                            if (retrievedTag.Synonyms != null) {
            //                                foreach (string relatedTag in retrievedTag.Synonyms) {
            //                                    Business.TagSynonym.InsertTagSynonym(retrievedTag.Name, relatedTag);
            //                                }
            //                            }
            //                        }

            //                        // insert the tag information associated with each sourced question


            //                    } while (retrievedTags != null && retrievedTags.HasMore);

            //                    tags.Clear();
            //                }
            //            }
            //            }
            //        }

            //        questionIds.Clear();
            //    }
            //}

            /* Question Tags */

            //List<DataObjects.Question> questions = Business.QuestionURL.SelectQuestionURL();

            //List<string> questionIds = new List<string>();

            //// for each question retrieved from the education overflow db
            //foreach (DataObjects.Question question in questions) {

            //    questionIds.Add(string.Format("{0}", question.ApiQuestionId));
            //    if (questionIds.Count == 99 || question == questions[questions.Count - 1]) {

            //        // query stake exchange for the tags associated with the question
            //        var questionTagQueryBuilder = new QuestionAPIQueryBuilder()
            //        .SetPage(new StackExchangeAPI.Page(1, 100))
            //        .SetMethodParameterValues(questionIds)
            //        .SetSite("stackoverflow")
            //        .SetAPIVersion("2.2/")
            //        .SetFilter("!-MOiNm40ELxaqMD_hv-_k4LsCQknpPZi0");

            //        IQuery<Question> questionTagQuery = questionTagQueryBuilder.GetQuery();

            //        ResponseWrapper<Question> queryResults = StackExchangeAPIClient.GetResponse<Question>(questionTagQuery);

            //        foreach (Question retrievedQuestion in queryResults.Items) {
            //            foreach (string tag in retrievedQuestion.Tags) {
            //                Business.QuestionTag.InsertQuestionTag(retrievedQuestion.Url, tag);
            //            }
            //        }
            //    }
            //}

            /* Old Test Code */

            //WebRequest request = WebRequest.Create("http://api.stackexchange.com/2.2/answers?order=desc&sort=activity&site=stackoverflow&filter=!Ldk(uYFB0jj2D42wej1Pr5");
            //WebRequest request = WebRequest.Create("http://api.stackexchange.com/2.2/tags?page=1&pagesize=90&order=desc&sort=popular&inname=computer&site=stackoverflow&filter=!9WA((BMGG");
            //WebRequest request = WebRequest.Create("http://api.stackexchange.com/2.2/questions?page=1&pagesize=5&order=desc&sort=activity&site=stackoverflow&filter=!9WA((I.pG");
            //request.Method = "GET";

            //WebResponse response = request.GetResponse();

            //string json;
            //MemoryStream decompressedStream = new MemoryStream();
            //GZipStream compressedStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);

            //compressedStream.CopyTo(decompressedStream);
            //decompressedStream.Seek(0, SeekOrigin.Begin);

            //using (StreamReader reader = new StreamReader(decompressedStream, System.Text.Encoding.UTF8)) {
            //    json = reader.ReadToEnd();
            //}

            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Question>));
            //MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            //StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Answer> obj = (StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Answer>)ser.ReadObject(stream);
            //StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Tag> obj = (StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Tag>)ser.ReadObject(stream);
            //StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Question> obj = (StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Question>)ser.ReadObject(stream);

            //stream.Close();
            //compressedStream.Close();
            //decompressedStream.Close();
        }
    }
}