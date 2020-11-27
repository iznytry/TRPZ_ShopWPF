using System;
using System.ComponentModel;
using ShopWPF.dto;

namespace ShopWPF.Model
{
    class MainModel : INotifyPropertyChanged
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private string _errMsg;
        private ProductModel _product = new ProductModel();
        private UserModel _userModel = new UserModel();
        private OrderModel _orderModel = new OrderModel();
        public void createOrder(string username)
        {
            UserDTO user = tryGetUserOrSetErrorMessage(username);
            if (user == null)
            {
                return;
            }
            //OrderDTO order = new OrderDTO(product,user, DateTime.Now);
            //_orderModel.saveOrder(order);
        }

        

        public string ErrorMessage
        {
            get
            {
                return _errMsg;
            }
            set
            {
                _errMsg = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

       
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private UserDTO tryGetUserOrSetErrorMessage(string username)
        {
            try
            {
                return _userModel.getUserByUsername(username);

            }
            catch (NullReferenceException e)
            {
                ErrorMessage = e.Message;
                return null;
            }
        }
        private ProductDTO getProductByName(string name)
        {
            try
            {
                return _product.getProductByName(name);

            }
            catch (NullReferenceException e)
            {
                ErrorMessage = e.Message;
                return null;
            }
        }


    }
}