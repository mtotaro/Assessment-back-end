using DTO;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;


namespace DataAccess
{
    public class ClientRepository
    {
        public ClientRepository()
        {
            this.ConfigMapping();
        }

        private AutoMapper.IMapper Mapper;

        private void ConfigMapping()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<Client, ClientDTO>();
                 cfg.CreateMap<List<Client>, List<ClientDTO>>();
             });
            this.Mapper = config.CreateMapper();
        }

        private void GetAllClients()
        {
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(@"http://www.mocky.io/v2/5808862710000087232b75ac");
            StreamReader reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            this._clients = JsonConvert.DeserializeObject<Clients>(json).clients;
        }

        private List<Client> _clients { get; set; }
        public List<ClientDTO> Clients
        {
            get
            {
                if (this._clients == null)
                {
                    this.GetAllClients();
                }
                //this.Mapper.Map<List<ClientDTO>>(this._clients);
                return this._clients.Select(x => this.Mapper.Map<ClientDTO>(x)).ToList();
            }
        }

        public ClientDTO GetById(Guid id)
        {
            return this.Clients.Where(x => x.Id.CompareTo(id)==0).FirstOrDefault();
        }

        public ClientDTO GetByName(string name)
        {
            return this.Clients.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
