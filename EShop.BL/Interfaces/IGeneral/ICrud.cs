using System.Collections.Generic;

namespace EShop.BL.Interfaces
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T FindByName(string modelName);
        T FindById(int modelId);      
    }
}