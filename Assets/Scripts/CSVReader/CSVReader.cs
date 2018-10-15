using System.Collections.Generic;

namespace CSVReader
{
    public abstract class CSVReader<T>
    {
    
        protected virtual List<T> Data
        {
            get;
        }


        public CSVReader()
        {
            Data = new List<T>();
            GetContent();
        }

        public virtual List<T> GetList()
        {
            return Data;
        }

        protected abstract void GetContent();

    }
}
