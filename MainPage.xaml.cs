using System.Net;
using LeonPrueba3.API;
using Newtonsoft.Json;

namespace LeonPrueba3;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        // aqui crear la ruta para acceder a la api generalmente en la documentacion de dan este dato
        WebRequest request = WebRequest.Create("https://randomuser.me/api/");
        //esto de header siempre cambia dependiendo de la api tienes que ver en la documentacion de la tuya que se pone
       // request.Headers.Add("X-TheySaidSo-Api-Secret", "YOUR API KEY HERE");
        // aqui checas si tienes respuesta de la api dependiendo del error o no tienes acceso o esta mal la ruta
        WebResponse response = request.GetResponse();
        // este client se usa para otra cosa ignoralo
        //var client = new HttpClient();
		using (Stream dataStream = response.GetResponseStream())
        {
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            // aqui extraes la informacion de la api y se vuelve todo un string en fotmato json 
            string responseFromServer = reader.ReadToEnd();
            // este trim solo quita basura como dobles espacios y así
            responseFromServer = responseFromServer.Trim();             // aqui crear la clase que tienes que sacar de tu api la mia se llama root, esto tambien depende de tu api y los metodos
            var resultado = JsonConvert.DeserializeObject<Root>(responseFromServer);             // Display the content.
																								 // aqui saco cosas especificas por que mi api devuelve un monton de cosas eso tambien tienes que verle 
			API.Text = resultado.results[0].phone;
        }
        // si no pones esto se muere , porque si no nunca deja de jalar datos de la api
        response.Close();
    }
}

