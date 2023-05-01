using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Common.Enums
{
    public enum OrderByType // Gönderilen değere göre sıralama methodlarının (örn: GetAllAsync) ne tür sıralama yapacağını belirlemek için kullandığımız enum nesnemiz.
    {  
        ASC = 1,
        DESC = 2,
    }
}
