using KennelCarolinekilde.Models.Repos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KennelCarolinekilde.ViewModels
{
    public class DBViewModel : ViewModelBase
    {

        private DataTable dataTable;
        private DogRepo dogRepo;

        public DataTable DogDataTable // Bind the DataGrid (ExcelFilePresenter) to the DogDataTable Property
        {
            get { return dataTable; }
            set
            {
                dataTable = value;
                OnPropertyChanged(nameof(DogDataTable));
            }
        }

        public DBViewModel()
        {
            dogRepo = new DogRepo(); //Initialize the repository
        }

       public DataTable LoadDataFromExcel(string filePath)
        {
            DataTable data = dogRepo.LoadDataFromExcel(filePath);

            if(data != null && data.Rows.Count > 0 ) 
            {
                DogDataTable = data;
                MessageBox.Show("Data loaded successfully");
            }
            else
            {
                MessageBox.Show("No data loaded");
            }
            return data;
        }

        public void UpdateDatabase(DataTable data)
        {
            if(dataTable != null && data.Rows.Count > 0) 
            {
                dogRepo.UpdateDatabase(data);
            }
            else 
            {
                MessageBox.Show("No Data to update");
            }
        }


    }
}
