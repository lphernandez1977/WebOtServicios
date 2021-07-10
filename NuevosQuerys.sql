select * from Tb_OT_Encabezado

--96524830&pNumOt=10&pCodAct=267

select * from Tb_ActividadesxOT 
where 
rut_empresa = 96524830 and
num_ot = 10 and
Cod_Act = 267
----------*********************************************************


--*******************************************  
--creado:Patricio Hernández  
--29/06/2017  
--actualiza estado actividad orden de trabajo
--*******************************************  
alter proc sp_actualiza_EstadoActividadOT
@prut_empresa float,
@pnum_ot float,
@pCod_Act float
as

begin
	update Tb_ActividadesxOT
	set Act_Realizada = 'Y',
	Fecha_Realizacion_Act = getdate()
	where
	rut_empresa = @prut_empresa and
	num_ot = @pnum_ot and
	Cod_Act = @pCod_Act
end
 
 go

--*******************************************  
--creado:Patricio Hernández  
--29/06/2017  
--actualiza estado orden de trabajo
--*******************************************
alter proc sp_actualiza_CerrarOrdendeTrabajo  
@prut_empresa float,
@pnum_ot float,
@Pgi_Salida INT OUTPUT,                
@pMensaje_Error VARCHAR(255)OUTPUT,                
@pMod_Err_Sp VARCHAR(255)output
as
--verifico si existen actividades pendientes
declare @Tpend int

set @Tpend = (select COUNT(*) from Tb_ActividadesxOT where rut_empresa = @prut_empresa and num_ot = @pnum_ot and Act_Realizada = 'N')
set @pMod_Err_Sp = 'existen '+ @Tpend + ' tareas pendienteste'

if @Tpend = 0
	begin
		begin try
			begin tran
			--actualizo encabezado
			SET @pMod_Err_Sp = 'Error Actualiza encabezado' 
			update Tb_OT_Encabezado 
			set fecha_termino_ot = getdate(),
			estado = 3
			where rut_empresa = @prut_empresa and num_ot = @pnum_ot 

			--actualizo detalle
			SET @pMod_Err_Sp = 'Error Actualiza detalle' 
			update Tb_OT_Detalle 
			set estado_mantencion = 'T'		
			where rut_empresa = @prut_empresa and num_ot = @pnum_ot 
			-- executamos transaccion                       
			COMMIT TRANSACTION                   
			SET @Pgi_Salida = 1                
			SET @pMensaje_Error = 'Operación Finalizada en forma correcta'                
			SET @pMod_Err_Sp = 'bloques executados correctamente'                
			SET @pMod_Err_Sp = @pMod_Err_Sp                 
		END TRY                
		BEGIN CATCH                
			ROLLBACK TRANSACTION                
			SET @Pgi_Salida = 0                
			SET @pMensaje_Error = ERROR_MESSAGE()                
			SET @pMod_Err_Sp = @pMod_Err_Sp                   
		END CATCH                 
	END
		else
		SET @Pgi_Salida = 0
		SET @pMensaje_Error = 'Existen Actividades Pendientes en OT'                		
		SET @pMod_Err_Sp = @pMod_Err_Sp   
		
 go

--*******************************************  
--creado:Patricio Hernández  
--29/06/2017  
--selecciona dispositivos
--*******************************************
create proc sp_sel_FamiliaEquipos
@prut_empresa float
as
select 
a.rut_empresa,
--a.nom_equipos,
--a.Nom_Disp,
--b.cod_nom_dispo,
--b.Nom_Disp,
c.CodTipOt,
c.NomTipOt
from Tb_Equipos as a
inner join Tb_Tipo_Dispositivo as b on (a.Cod_Nom_Dispo = b.cod_nom_dispo)
inner join Tb_Tipo_OT as c on (b.Familia = c.CodTipOt)
--where 
group by
a.rut_empresa,
c.CodTipOt,
c.NomTipOt
 
	

