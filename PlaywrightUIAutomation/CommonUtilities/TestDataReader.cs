using Newtonsoft.Json.Linq;

namespace PlaywrightUIAutomation.CommonUtilities
{
    public class TestDataReader
    {
        public async Task<string> ReadTestDataFromTestDataFile(string tokenname, string filePath)
        {
            try
            {                
                var testDataFileDetails = File.ReadAllText(filePath);
                var testDataTokens = JToken.Parse(testDataFileDetails);

                return testDataTokens.SelectToken(tokenname).Value<string>();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
