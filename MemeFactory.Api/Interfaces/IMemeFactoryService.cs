using System.Drawing;

namespace MemeFactory.Api.Interfaces
{
    public interface IMemeFactoryService
    {
       public byte[] AddText(IFormFile file, string text); 
    }
}
