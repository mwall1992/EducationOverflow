using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.TagSynonymTableAdapters;

namespace Business {
    
    public class TagSynonym {
    
        private static TagSynonymTableAdapter tagSynonymTableAdapter = new TagSynonymTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<string> SelectTagSynonyms(string tagName) {
            List<string> synonyms = new List<string>();

            Data.TagSynonym.TagSynonymDataTable tagSynonymDataTable = 
                tagSynonymTableAdapter.GetData(tagName);
            foreach (Data.TagSynonym.TagSynonymRow row in tagSynonymDataTable.Rows) {
                synonyms.Add(row.Synonym);
            }

            return synonyms;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertTagSynonym(string tagName, string synonym) {
            try {
                tagSynonymTableAdapter.Insert(synonym, tagName);
            } catch (Exception e) {
                // stub
            }
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
