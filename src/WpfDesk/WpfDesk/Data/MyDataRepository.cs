using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WpfDesk.Data
{
    public class MyDataRepository
    {
        private readonly TaskCompletionSource<string> _taskCompletionSource = new TaskCompletionSource<string>();

        public TaskCompletionSource<string> TaskCompletionSource
        {
            get { return _taskCompletionSource; }
        }

        public MyDataRepository()
        {
            ReadAsync();
        }

        public static string Read()
        {
            var tr = new StreamReader(@"Data\MyDb.xml");

            tr.ReadLine();
            return tr.ReadToEnd();
        }

        public void ReadAsync()
        {
            Thread.Sleep(10000);
            var tr = new StreamReader(@"Data\MyDb.xml");

            tr.ReadToEndAsync().ContinueWith(t => TaskCompletionSource.SetResult(t.Result));
        }
    }
}
