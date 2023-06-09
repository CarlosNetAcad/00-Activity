﻿using System;
using System.Collections.Generic;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using _00_Activities.src.Contacts.Domain.Entity;
using _00_Activities.src.Contacts.App.Presenter.ViewHolders;
using static System.Net.Mime.MediaTypeNames;

namespace _00_Activities.src.Contacts.Domain.Service
{
	public class ContactAdapter : RecyclerView.Adapter
	{
		public Action<int> ItemClicked;

		private IList<Contact> _contactList = new List<Contact>();

		public ContactAdapter( IList<Contact> contacts)
		{
			_contactList = contacts;
		}

        public override int ItemCount => _contactList.Count;


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
			var currentContact    = _contactList[position];
			var contactViewHolder = holder as ContactVH;

			contactViewHolder.Name.Text  = currentContact.FullName;
			contactViewHolder.Phone.Text = currentContact.Phone;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType )
		{
			View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout._contact_index_list, parent, false );

			var holder    = new ContactVH( itemView.RootView, OnItemClicked  );

			return holder;
		}

		public void SetData( IList<Contact> contacts )
		{

			_contactList = contacts;

			this.NotifyDataSetChanged();
		}

		private void OnItemClicked(int position)
        {
            if (ItemClicked != null)
            {
                ItemClicked(position);
            }
        }
    }
}

