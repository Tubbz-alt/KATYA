using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATYA
{
    public class KATYAMiscellaneous
    {
        public StatusObject Login()
        {
            StatusObject SO = new StatusObject();
            try
            {
                KATYAWebRequest LoginRequest = new KATYAWebRequest("http://localhost/claims/index.cfm?fusebox=MTRsec&fuseaction=act_login&");
                LoginRequest.AddRequestParameters("sleUserName", "mmshawn");
                LoginRequest.AddRequestParameters("slePassword", "AE27F329C3F17A5E7F701CB82231B297C48E9B1D00408F799DE0EB0F93536AFF51F0B71C87040AF8E903683BB81FB7B2CF18B3A742162D4E7C4D837167190F95");
                LoginRequest.AddRequestParameters("Nonce", "MTEvMzAvMjAxNyAwOTo0MDo0NTh4CF8EDA4C2B1850CD7E2020AB1BDA8995F82A68E2B99DB74F37CBECA1FEE7DF7C20B8DDEB6B1F03434045A3942F4B32BF7A1C2BD0E4BC2516DD19F06FCD38129");
                LoginRequest.AddRequestParameters("hpwd", "05D64E496CA79F5D135BB85C5D6016AB426A2A34F4BC712BE8ECD5CE97571ADE0D79A5FDBA58DD8B005C2C7C38B5333247F2352A181CC1681625EAD8398DE466");
                LoginRequest.AddRequestParameters("Login", "");
                Console.WriteLine(LoginRequest.GetURLEncodedString());
                LoginRequest.Post();
            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
