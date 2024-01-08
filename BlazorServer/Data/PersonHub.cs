using BlazorServer.Models;
using Microsoft.AspNetCore.SignalR;

namespace BlazorServer.Data
{
    public class PersonHub:Hub
    {
        public async Task SendPersons(List<Person> persons)
        {
            await Clients.All.SendAsync("ReceivePersons", persons);
        }
    }
}
