using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.D1.Comum
{
    public static class Metodos
    {
        static string caminho = "http://localhost/Clientes.D1.WebApi/";
        public static IDictionary<int, string> GetEnumToDropDown<TEnum>() where TEnum : struct
        {
            var enumerationType = typeof(TEnum);

            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enum não encontrado.");

            var dictionary = new Dictionary<int, string>();

            foreach (int value in Enum.GetValues(enumerationType))
            {
                var memInfo = enumerationType.GetMember(enumerationType.GetEnumName(value));
                var descriptionAttribute = memInfo[0]
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute;

                var name = descriptionAttribute.Description;
                dictionary.Add(value, name.ToString());
            }
            return dictionary;
        }

        private static string MontaParamentros(string[] parametros)
        {
            if (parametros.Length == 0 || parametros[0] == "") return "";

            var ret = "";
            foreach (var item in parametros)
            {
                ret = ret + item + "/";
            }

            return ret;
        }

        public static async Task<ObjRetorno> CallApiGetMetodo(string controller, string metodo, params string[] parametros)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(caminho + controller + "/" +
                    metodo + "/" + MontaParamentros(parametros));

                string apiResponse = await response.Content.ReadAsStringAsync();

                ObjRetorno ret = new ObjRetorno();
                ret.status = 200;
                ret.mensagem = "";
                ret.dados = apiResponse;
                return ret;
            }
            catch (Exception ex)
            {
                ObjRetorno ret = new ObjRetorno();
                ret.status = 201;
                ret.mensagem = "Erro: " + ex.Message;
                return ret;
            }

        }

        public static async Task<ObjRetorno> CallApiPostMetodo(string controller, string metodo, object dados)
        {
            try
            {
                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(
                    caminho + controller + "/" + metodo, content);
                response.EnsureSuccessStatusCode();

                string apiResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ObjRetorno>(apiResponse);
            }
            catch (Exception ex)
            {
                ObjRetorno ret = new ObjRetorno();
                ret.status = 201;
                ret.mensagem = "Erro: " + ex.Message;
                return ret;
            }

        }
    }
}
