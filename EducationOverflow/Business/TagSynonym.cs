using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class TagSynonym {
    
        private static TagSynonymTableAdapter tagSynonymTableAdapter = new TagSynonymTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.TagSynonymDataTable SelectTagSynonyms(string tagName) {
            return tagSynonymTableAdapter.GetData(tagName);

            //List<string> synonyms = new List<string>();

            //DataAccess.EducationOverflow.TagSynonymDataTable tagSynonymDataTable = 
            //    tagSynonymTableAdapter.GetData(tagName);
            //foreach (DataAccess.EducationOverflow.TagSynonymRow row in tagSynonymDataTable.Rows) {
            //    synonyms.Add(row.Synonym);
            //}

            //return synonyms;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertTagSynonym(string tagName, string synonym) {
            tagSynonymTableAdapter.Insert(synonym, tagName);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateTagSynonym(string tagName, string synonym, 
                string originalTagName, string originalSynonym) {
            tagSynonymTableAdapter.Update(tagName, synonym, originalTagName, originalSynonym);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteTagSynonym(string originalTagName, string originalSynonym) {
            tagSynonymTableAdapter.Delete(originalSynonym, originalTagName); 
        }
    }
}
