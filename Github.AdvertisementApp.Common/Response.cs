using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Common
{
    public class Response : IResponse // Veri taşımayan Response yapısı.
    {
        public Response(ResponseType responseType) // constructor 1
        {
            ResponseType = responseType;
        }

        public Response(ResponseType responseType, string message) // constructor 2
        {
            ResponseType = responseType;
            Message = message;
        }

        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }

    public enum ResponseType
    {
        Success,
        ValidationError,
        NotFound
    }
//C# gibi birçok programlama dilinde, Enumerations (kısaltması Enum) adı verilen bir veri türü bulunur. Enum, belirli sabit değerler kümesine atanmış bir adlandırma öğesidir.

//Yukarıdaki kodda, "ResponseType" adında bir Enum oluşturulmuştur.Bu Enum, uygulama kodunda belirli bir işlem sonucunun durumunu belirtmek için kullanılabilir.
//Enum, üç sabit değer içerir: "Success" (Başarılı), "ValidationError" (Doğrulama Hatası) ve "NotFound" (Bulunamadı).

//Bu kod, örneğin, bir web hizmeti çağrısının yanıtını ele almak veya bir veritabanı işleminin sonucunu belirtmek gibi durumlarda kullanılabilir.
//Enum, kod okunabilirliğini artırır ve sabitlerle karşılaştırıldığında kodda daha az hata yapma şansı verir.
}



////----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//Response Kullanım Amacı:

//    Bu C# kodu, "Response" sınıfını ve "ResponseType" adında bir enum'u içerir. "Response" sınıfı, bir uygulama işleminin sonucunu temsil etmek için kullanılır. İki farklı yapılandırıcıya sahip olan "Response" sınıfı, "ResponseType" ve opsiyonel bir "Message" parametresi alır.

//Bu yapı, uygulama işlemlerinin sonuçlarını standartlaştırmak için sıklıkla kullanılır. Örneğin, bir web hizmeti çağrısının yanıtını ele alırken, Response sınıfı, yanıtın türünü (başarı, doğrulama hatası, bulunamadı vb.) ve gerekirse bir mesajı içerebilir.

//Örneğin, bir kullanıcının adını ve e-posta adresini güncelleyen bir işlem düşünelim. Eğer işlem başarılı olursa, Response sınıfının "Success" türünde bir yanıt döndürülebilir. Eğer güncelleme sırasında doğrulama hatası oluşursa, Response sınıfının "ValidationError" türünde bir yanıtı döndürülebilir. Aynı şekilde, bir kullanıcının bulunamaması durumunda, Response sınıfının "NotFound" türünde bir yanıtı döndürülebilir.

//Bu yapı, uygulama işlemlerinin sonuçlarının standardize edilmesini sağlayarak, kodun okunabilirliğini artırır ve hata ayıklama sürecini kolaylaştırır.
