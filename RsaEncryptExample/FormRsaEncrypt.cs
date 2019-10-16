using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RsaEncryptExample
{
    public partial class FormRsaEncrypt : Form
    {
        public FormRsaEncrypt()
        {
            InitializeComponent();
            this.Text = "RSA 加密解密";
            textBoxEncrypt.ReadOnly = true;
            textBoxDecrypt.ReadOnly = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //使用默认密钥创建RSACryptoServiceProvider 对象
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //显示包含公钥/私钥对的XML 表示形式，如果只显示公钥，将参数改为false 即可
            richTextBoxKeys.Text = rsa.ToXmlString(true);
            //将被加密的字符串转换为字节数组
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(textBoxInput.Text);
            try
            {
                //得到加密后的字节数组
                byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);
                textBoxEncrypt.Text = Encoding.UTF8.GetString(encryptedData);
                //得到解密后的字节数组
                byte[] decryptedData = rsa.Decrypt(encryptedData, false);
                textBoxDecrypt.Text = Encoding.UTF8.GetString(decryptedData);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}

