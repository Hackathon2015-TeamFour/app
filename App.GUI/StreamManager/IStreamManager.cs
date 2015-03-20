using App.DLL.Data;

namespace App.GUI.StreamManager
{
    interface IStreamManager
    {
        void Process(mdf_stream entry);
    }
}
