using Humanizer;
using PharmacyApp.Models;
using PharmacyApp.Repositories;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Services
{
    public class Form2Service : IForm2Service<Form2ViewModel>
    {
        private readonly IRepository<Form2> _repository;

        public Form2Service(IRepository<Form2> repository)
        {
            _repository = repository;
        }
        public async Task<Form2ViewModel> CreateAsync(Form2ViewModel entity)
        {
            //submit a new entry to the database form2
            var newModel = new Form2
            {

                name = entity.name,
                description = entity.description,
                CustomerId = entity.CustomerId,

            };

            //save the entry to the database
            await _repository.AddAsync(newModel);

            //map back onto the view model
            var newViewModel = new Form2ViewModel
            {
                name = newModel.name,
                description = newModel.description,
                CustomerId = newModel.CustomerId


            };

            return newViewModel;
        }

        public Task DeleteAsync(int id)
        {
            return  _repository.DeleteAsync(id);
            
        }

        public async Task<IEnumerable<Form2ViewModel>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            var viewModels = entities.Select(e => new Form2ViewModel
            {
                name = e.name,
                description = e.description,

             
            });

            return viewModels;
        }

        public async Task<Form2ViewModel> ReadOneAsync(int id)
        {
            var model = await _repository.GetByIdAsync(id);

            //map to the viewModel
            var viewModel = new Form2ViewModel
            {
                name = model.name,
                description = model.description,

                
            };

            return viewModel;
        }

        public async Task<Form2ViewModel> UpdateAsync(Form2ViewModel viewModel)
        {
            var entity = await _repository.GetByIdAsync(viewModel.id);


            if (entity == null)
            {
                throw new Exception();
            }

            entity.name = viewModel.name;
            entity.description = viewModel.description;

            //map updated entity back to ViewModel if needed
            //  _mapper.Map(viewModel, entity);

            await _repository.UpdateAsync(entity);

            return new Form2ViewModel
            {
                name = entity.name,
                description = entity.description,
            };
            
        }

        /*
         *     
                public async Task AddAsync(Form2 form, int customerId)
                {
                    await _repository.AddAsync(form, customerId);
                }



        public async Task<IEnumerable<Form2ViewModel>> GetAllByCustomerIdAsync(int customerId)
        {
            // Get the forms from the repository
            var forms = await _repository.GetAllByCustomerIdAsync(customerId);

            // Convert the data into a ViewModel 
            var viewModels = forms.Select(form => new Form2ViewModel
            {
                Id = form.Id,
                Name = form.Name,
                Description = form.Description,
                CustomerId = form.CustomerId
                // Other properties
            });

            return viewModels;
        }
         */
    }
}
