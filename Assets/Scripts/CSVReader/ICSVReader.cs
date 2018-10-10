using System.Collections.Generic;

public interface ICSVReader<T>
{

    List<T> GetList();

}
