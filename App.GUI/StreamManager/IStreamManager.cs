using App.DLL.Data;

namespace App.GUI.StreamManager
{
    interface IStreamManager
    {
        void process(mdf_stream entry);
    }
}
