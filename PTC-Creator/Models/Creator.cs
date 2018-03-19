using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PTC_Creator.Models
{
    public class Creator
    {
        WorkerModel worker;
        StatusModel status;

        int local_count = 0;

        public Creator(WorkerModel _worker, StatusModel _status)
        {
            worker = _worker;
            status = _status;
        }

        public void Start()
        {

        }
    }
}
