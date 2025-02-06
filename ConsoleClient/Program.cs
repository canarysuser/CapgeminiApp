//Add Project Reference -> CapgAppLibrary 

using CapgAppLibrary;
using System.Net.Http.Json;

Console.WriteLine("Press a key after the API servers start.");
Console.ReadKey();

Console.WriteLine("Fetching List of Customers");
await Fetch.CustomersList(); // Fetching List of Customers
Console.WriteLine("\n******* End of List ****** ");

//Console.WriteLine("Fetching details for 'ALFKI' ");
//await Fetch.CustomerDetails("ALFKI"); // Fetching details for 'ALFKI'
//Console.WriteLine("\n******* End of Details ****** ");


Console.WriteLine("Press a key to terminate");
Console.ReadKey();



public static class Fetch
{
    static string BaseServiceUrl = "http://localhost:7001/";
    static string ApiUrl = "api/customers";
    public static async Task CustomersList()
    {
        using (HttpClient client=new HttpClient())
        {
            //set the base address
            client.BaseAddress = new Uri(BaseServiceUrl);
            //place a GET request to the API
            var response = await client.GetAsync($"{ApiUrl}/list");
            //check whether the response is successful
            if (response.IsSuccessStatusCode)
            {
                //parse the response and display the data
                var customers = await response.Content
                                .ReadFromJsonAsync<List<Customer>>();
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            } else
            {
                Console.WriteLine("Error fetching data");
            }
        } 

            
    }
}