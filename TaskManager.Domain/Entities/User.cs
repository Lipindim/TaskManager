using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TaskManager.Domain.Entities.Base;

namespace TaskManager.Domain.Entities
{
    [DataContract]
    public class User: BaseEntity, INotifyPropertyChanged
    {
        [DataMember]
        public string FIO { get; set; }
        [DataMember]
        public string Post { get; set; }
        [DataMember]
        public bool IsBoss { get; set; }
        [DataMember]
        public bool IsManager { get; set; }
        [DataMember]
        public int? ManagerID { get; set; }
        [DataMember]
        public Role Role { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Subdivision { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public byte[] PictureArray { get; set; }

        //[DataMember]
        public List<User> ChildUsers { get; set; }

        public void AddChildUser(User childUser)
        {
            childUser.ManagerID = this.ID;
            childUser.Manager = this;
            if (ChildUsers == null)
            {
                ChildUsers = new List<User>();
                ChildUsers.Add(childUser);
            }
            else
            {
                List<User> users = ChildUsers.Union(new List<User>()).ToList();
                users.Add(childUser);
                ChildUsers = users;
            }
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("ChildUsers"));
            }
        }

        [NotMapped]
        public BitmapImage PictureImage
        {
            get
            {
                if (PictureArray == null)
                {
                    return null;
                }
                MemoryStream ms = new MemoryStream(PictureArray);
                BitmapImage returnImage = new BitmapImage();
                returnImage.BeginInit();
                returnImage.StreamSource = ms;
                returnImage.EndInit();
                return returnImage;
            }
            set
            {
                if (value != null)
                {
                    byte[] data;
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(value));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        data = ms.ToArray();
                    }
                    PictureArray = data;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("PictureImage"));
                    }
                }
            }
        }


        [ForeignKey("ManagerID")]
        [DataMember]
        public User Manager { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RemoveManager()
        {
            List<User> users = Manager.ChildUsers.Union(new List<User>()).ToList();
            users.Remove(this);
            Manager.ChildUsers = users;

            Thread.Sleep(100);
            Manager.PropertyChanged(Manager, new PropertyChangedEventArgs("ChildUsers"));

            ManagerID = null;
        }
    }
    public enum Role
    {
        Admin,
        User
    }
}
