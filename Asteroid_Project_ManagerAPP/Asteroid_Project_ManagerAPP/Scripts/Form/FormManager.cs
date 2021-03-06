﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid_Project_ManagerAPP.Scripts.Form
{
    public static class FormManager
    {
        public static AnaForm anaForm;
        public static System.Windows.Forms.Form AnaFormSet()
        {
            anaForm = new AnaForm();
            return anaForm;
        }
        static string sonGirilenForm;
        /// <summary>
        /// acilacak formu ANAFROM MDI'sında acar formlar_Kapatilsinmi true ise acık olan tüm formları kapatır.
        /// </summary>
        public static void FORM_AC(System.Windows.Forms.Form acilacak_Form,bool formlar_kapatilsinmi)
        {
            if (sonGirilenForm == acilacak_Form.Name && System.Windows.Forms.Application.OpenForms[acilacak_Form.Name] != null)
            {
                Scripts.Form.Status.STATUS_LABEL("Durum:Zaten açmak istediğiniz penceredesiniz.", System.Drawing.Color.Cyan, 1000);
            }
            else
            {
                if (formlar_kapatilsinmi)
                {
                    for (int i = 0; i < anaForm.MdiChildren.Length; i++)
                    {
                        anaForm.BeginInvoke(new System.Windows.Forms.MethodInvoker(anaForm.MdiChildren[i].Close));
                    }
                }
                acilacak_Form.MdiParent = System.Windows.Forms.Application.OpenForms["AnaForm"];
                acilacak_Form.Show();
                if (acilacak_Form.Name == new profil().Name || acilacak_Form.Name == new team().Name ||  acilacak_Form.Name == new projeler().Name)
                {
                    sonGirilenForm = acilacak_Form.Name;
                }
                
                if (acilacak_Form.Name == new gorev_liste().Name || acilacak_Form.Name == new gorev_ekle().Name || acilacak_Form.Name == new Forms.gorev_takvim().Name || acilacak_Form.Name == new Forms.deadline().Name)
                {
                    anaForm.menuStrip2.Visible = true;
                }
                else anaForm.menuStrip2.Visible = false;
            }
        }
    }
}
