using System.Collections;

namespace PharmacyApp.Services
{
    public interface IFeedbackFormService<T> where T : class
    {
        Task<T> UpdateToForm();
        Task<T> DeleteFromForm(int formId);

        Task<T> CreateForm(T entity);

        Task<IEnumerable<T>> ReadForms();


    }
}
