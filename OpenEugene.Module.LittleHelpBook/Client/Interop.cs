using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace OpenEugene.Module.LittleHelpBook
{
    public class Interop
    {
        private readonly IJSRuntime _jsRuntime;

        public Interop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    }
}
