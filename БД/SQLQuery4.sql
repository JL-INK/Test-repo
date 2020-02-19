SELECT t.Name, (u.Quantity - a.Quantity) Quantity , a.Date Date  FROM Name t
join Sales a on t.ID = a.IDName
join Supply u on t.ID = u.IDName