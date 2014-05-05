using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public sealed class Page {
        
        public static Int32 MIN_PAGE_NUMBER = 1;

        public static Int32 MIN_PAGE_SIZE = 0;

        public static Int32 MAX_PAGE_SIZE = 100;

        public static Int32 DEFAULT_PAGE_NUMBER = 1;

        public static Int32 DEFAULT_PAGE_SIZE = 30;

        private Int32 pageNumber;

        private Int32 pageSize;

        public Page() {
            this.pageNumber = DEFAULT_PAGE_NUMBER;
            this.pageSize = DEFAULT_PAGE_SIZE;
        }

        public Page(Int32 page, Int32 pageSize) {
            this.pageNumber = page;
            this.pageSize = pageSize;
        }

        public Int32 PageNumber {
            get {
                return this.pageNumber;
            }

            set {
                if (value < MIN_PAGE_NUMBER) {
                    throw new ArgumentException(
                        string.Format("The page specified is {0}. The minimum page is {1}.",
                                        value, MIN_PAGE_NUMBER)
                    );
                }

                this.pageNumber = value;
            }
        }

        public Int32 PageSize {
            get {
                return this.pageSize;
            }

            set {
                if (value < MIN_PAGE_SIZE || value > MAX_PAGE_SIZE) {
                    throw new ArgumentException(
                        string.Format("The page size specified is {0}. A page size can be any"
                                        + "any integer value between {1} and {2} inclusive.",
                                        value, MIN_PAGE_NUMBER, MAX_PAGE_SIZE)
                    );
                }

                this.pageSize = value;
            }
        }

        public override string ToString() {
            return string.Format("page={0}&pagesize={1}", this.pageNumber, this.pageSize);
        }
    }
}
