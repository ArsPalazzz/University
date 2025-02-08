using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace CourseProject
{
    public class RecordDisplay
    {

        public decimal RECORD_ID { get; set; }
        public decimal? YEAR { get; set; }
        public decimal? COST { get; set; }
        public decimal? AMOUNT { get; set; }
        public decimal? SUPPLIER_ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string ARTIST_NAME { get; set; }
        public string ALBUM_NAME { get; set; }
        public string PICTURE { get; set; }
        public string STATUS { get; set; }
        public string SongsAString { get; set; }
        public string SongsBString { get; set; }
        public string GenresString { get; set; }
        public string SupplierNameString { get; set; }
        public List<string> SongsA { get; set; }
        public List<string> SongsB { get; set; }
        
        
        public List<string> Genres { get; set; }
        public List<string> SupplierNameList { get; set; }

        //public decimal SONG_ID { get; set; }
        //public string SONG_NAME { get; set; }

        //public string SIDE { get; set; }
        public System.DateTime? DATE_OF_DELIV_TO_WAREHOUSE { get; set; }

    }
}
