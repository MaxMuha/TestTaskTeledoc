using Microsoft.IdentityModel.Protocols;
using TestTaskTeledoc.Db;
using TestTaskTeledoc.Db.Models;
using TestTaskTeledoc.Models;

namespace TestTaskTeledoc.Helpers
{
    public static class Mapping
    {
        public static Client ToClient(this ClientViewModel clientViewModel)
        {
            return new Client
            {
                Id = clientViewModel.Id,
                TaxpayerIdentification = clientViewModel.TaxpayerIdentification,
                Name = clientViewModel.Name,
                Type = (TypeClient)(int)clientViewModel.Type,
                DateCreate = clientViewModel.DateCreate,
                DateUpdate = clientViewModel.DateUpdate,
                Founders = clientViewModel.Founders.ToFounders(),
            };
        }
        public static List<Client> ToClients(this List<ClientViewModel> clientViewModels)
        {
            var clients = new List<Client>();
            foreach (var client in clientViewModels)
            {
                clients.Add(client.ToClient());
            }
            return clients;
        }
        public static ClientViewModel ToClientViewModel(this Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                TaxpayerIdentification = client.TaxpayerIdentification,
                Name = client.Name,
                Type = (TypeClientViewModel)(int)client.Type,
                DateCreate = client.DateCreate,
                DateUpdate = client.DateUpdate,
                Founders = client.Founders.ToFounderViewModels(),
            };
        }
        public static List<ClientViewModel> ToClientViewModels(this List<Client> clients)
        {
            var clientViewModels = new List<ClientViewModel>();
            foreach (var client in clients)
            {
                clientViewModels.Add(client.ToClientViewModel());
            }
            return clientViewModels;
        }
        public static Founder ToFounder(this FounderViewModel founderViewModel)
        {
            return new Founder
            {
                Id = founderViewModel.Id,
                TaxpayerIdentification = founderViewModel.TaxpayerIdentification,
                FullName = founderViewModel.FullName,
                DateCreate = founderViewModel.DateCreate,
                DateUpdate = founderViewModel.DateUpdate,
            };
        }
        public static List<Founder> ToFounders(this List<FounderViewModel> foundersViewModel)
        {
            var founders = new List<Founder>();
            foreach (var founder in foundersViewModel)
            {
                founders.Add(founder.ToFounder());
            }
            return founders;
        }
        public static FounderViewModel ToFounderViewModel(this Founder founder)
        {
            return new FounderViewModel
            {
                Id = founder.Id,
                TaxpayerIdentification = founder.TaxpayerIdentification,
                FullName = founder.FullName,
                DateCreate = founder.DateCreate,
                DateUpdate = founder.DateUpdate,
            };
        }
        public static List<FounderViewModel> ToFounderViewModels(this List<Founder> founders)
        {
            var foundersViewModel = new List<FounderViewModel>();
            foreach (var founder in founders)
            {
                foundersViewModel.Add(founder.ToFounderViewModel());
            }
            return foundersViewModel;
        }
    }
}
