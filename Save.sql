create procedure SPLayDuLieu_DV12
as
BEGIN
	
	
	if(object_id('tempdb..#tmp1')) is not null
	drop table #tmp1
	if(object_id('tempdb..#tmp2')) is not null
	drop table #tmp2
	if(object_id('tempdb..#tmp3')) is not null
	drop table #tmp3
	if(object_id('tempdb..#tmp4')) is not null
	drop table #tmp4


	select hs.SoPhatHanhGCN as SoGCN, ch.HoTen as Ten into #tmp1
	--, ch.SoDinhDanh as SoCMT
	from 
	tblHoSoCapGCN as hs
	inner join tblChuHoSoCapGCN as chs on hs.MaHoSoCapGCN = chs.MaHoSoCapGCN
	inner join tblChu as ch on ch.MaChu = chs.MaChu
	where hs.SoPhatHanhGCN <> '' and hs.SoPhatHanhGCN is not null 


	select distinct SoGCN ,(
		select Ten+',' from #tmp1 t2 where t1.SoGCN =t2.SoGCN order by Ten for xml path('')
	) as Ten into #tmp3
	--,
	--(
	--	select SoCMT+',' from #tmp1 t3 where t1.SoGCN = t3.SoGCN order by SoCMT for xml path('')
	--) as CM
	from #tmp1 t1
	group by SoGCN


	update #tmp3 set Ten = substring(Ten,1,Len(Ten)-1)
	select * from #tmp3


	select distinct hs.MaHoSoCapGCN as MaHoSo, hs.SoPhatHanhGCN as SoGCN, td.DiaChi, td.ToBanDo, td.SoThua,td.DienTich, dv.Ten into #tmp2
	from tblHoSoCapGCN as hs
	inner join tblThuaDatCapGCN as td on hs.MaHoSoCapGCN = td.MaHoSoCapGCN and substring(td.MaDonViHanhChinh , 4,3) =hs.MaXa
	inner join tblTuDienDonViHanhChinh as dv on td.MaDonViHanhChinh = dv.MaDonViHanhChinh
	where
	hs.SoPhatHanhGCN is not null and hs.SoPhatHanhGCN <>'' and
		ToBanDo is not null and SoThua is not null	
		   and Ltrim(Rtrim(ToBanDo)) <> '' and Ltrim(Rtrim(SoThua)) <>''	
			and Ltrim(Rtrim(ToBanDo)) <> '-' and Ltrim(Rtrim(SoThua)) <>'-'	
			 and Ltrim(Rtrim(ToBanDo)) <> '/' and Ltrim(Rtrim(SoThua)) <>'/'	
			  and Ltrim(Rtrim(ToBanDo)) <> '//' and Ltrim(Rtrim(SoThua)) <>'//'	
			   and Ltrim(Rtrim(ToBanDo)) <> '-/-' and Ltrim(Rtrim(SoThua)) <>'-/-'	
				and Ltrim(Rtrim(ToBanDo)) <> '-/' and Ltrim(Rtrim(SoThua)) <>'-/'	
				 and Ltrim(Rtrim(lower(ToBanDo))) <> N'trích đo'	 and Ltrim(Rtrim(lower(SoThua))) <>N'trích đo'	
				  and Ltrim(Rtrim(ToBanDo)) <> '00' and Ltrim(Rtrim(SoThua)) <>'00' 	
				   and Ltrim(Rtrim(ToBanDo)) <> N'(Trích Đo)' and Ltrim(Rtrim(SoThua)) <>N'(Trích Đo)'	
    				and Ltrim(Rtrim(ToBanDo)) <> '0' and Ltrim(Rtrim(SoThua)) <>'0'	
    				 and Ltrim(Rtrim(ToBanDo)) <> '-\\-' and Ltrim(Rtrim(SoThua)) <>N'-\\-'	
    				   and Ltrim(Rtrim(ToBanDo)) <> 'T?' and Ltrim(Rtrim(SoThua)) <>N'T?'	
        				and Ltrim(Rtrim(ToBanDo)) <> '\00\' and Ltrim(Rtrim(SoThua)) <>'\00\' 	
        				 and Ltrim(Rtrim(ToBanDo)) <> '(-/-)' and Ltrim(Rtrim(SoThua)) <>'(-/-)'	
        				  and Ltrim(Rtrim(ToBanDo)) <> './.' and Ltrim(Rtrim(SoThua)) <>'./.'	
        				   and Ltrim(Rtrim(ToBanDo)) <> '\\\\' and Ltrim(Rtrim(SoThua)) <>'\\\\'	
							and DienTich<> '' and DienTich is not null	
							
							order by hs.SoPhatHanhGCN
							
				
							
	create table #tmp4(
		SoGCN nvarchar(50),
		NoiDung nvarchar(max)
	)
	insert into #tmp4(SoGCN, NoiDung)
	select b.SoGCN, a.Ten+'; '+b.DiaChi+'; TBD:'+b.ToBanDo+'; ST:'+b.SoThua+'; DT:'+convert(nvarchar,b.DienTich)+'; GCN:'+b.SoGCN
	from #tmp3 as a inner join #tmp2  as b on a.SoGCN = b.SoGCN


	select SoGCN,NoiDung from #tmp4
	if(object_id('tempdb..#tmp1')) is not null
	drop table #tmp1
	if(object_id('tempdb..#tmp2')) is not null
	drop table #tmp2
	if(object_id('tempdb..#tmp3')) is not null
	drop table #tmp3
	if(object_id('tempdb..#tmp4')) is not null
	drop table #tmp4



END

