﻿using System.ComponentModel.DataAnnotations;

namespace OnlineMall.Models
{
	public class Invoice
	{
		public int InvoiceId { get; set; }
		public double InvoiceAmount { get; set; }

		public string? DateOfIssue { get; set; }
		public string? Contractor { get; set; }
		public string? OwnerID { get; set; } //user id from Ms Identity
		public InvoiceStatus Status { get; set; }
	}

	public enum InvoiceStatus
	{
		Submitted,
		Approved,
		Rejected
	}
}
