$(document).ready(function(){
	
	$("form").submit(function(){
	//aqui podemos llamar alguna funcion por defecto o nada. 
	//El return false va igual
	return false;
	});

	/*mascara a caja de texto*/
	$("#txt_numero_telefono").mask("(9) 9999-9999");
	
	/*solo numeros*/
	$("#txt_numero_telefono").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) || 
            (e.keyCode >= 35 && e.keyCode <= 39)) {
			return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
	});	
	
	
	$("#send").click(function () {  
		if (Validar_Correo()){
			Enviar_Correo();
		}
		else{
			$("#txt_nombre_apellido").focus();
		}
	});
	
/*	
	$("#send").click(function (){  	
		Validar_Correo();		  
	});
		
	$("#send").click(function (){  	
		Enviar_Correo();		  
	});  
	
	$("#send").click(function (){  	
		Validar_Comentario();		  
	});  
*/
});

function Validar_Nombre(){	
	if($("#txt_nombre_apellido").val() =='') {  		
			$("#txt_nombre_apellido").focus();
			$('#txt_nombre_apellido').css('border', '2px solid #FF0000');
			return false;  
		}
		else{
			$('#txt_nombre_apellido').css('border', '2px solid #FFFFFF');
			return true;
		}
}

function Validar_Cajas(){	
	if(($("#txt_numero_telefono").val().length < 13)||("#txt_numero_telefono").val()=='') {  		
			$("#txt_numero_telefono").focus();
			$('#txt_numero_telefono').css('border', '2px solid #FF0000');
			return false;  
		}
		else{
			$('#txt_numero_telefono').css('border', '2px solid #FFFFFF');
		}
}

function Validar_Comentario(){	
	if($("#txt_comentario").val()=='') {  		
			$("#txt_comentario").focus();
			$('input#txt_comentario').css('border', '2px solid #FF0000');
			return false;  
		}
		else{
			$('#txt_comentario').css('border', '2px solid #FFFFFF');
			return true;
		}
}

function Validar_Correo(){
	if($("#email").val().indexOf('@', 0) == -1 || $("#email").val().indexOf('.', 0) == -1) {
			$('input#email').css('border', '2px solid #FF0000');
			$("#email").focus();
            return false;		
        }
	else{
			$('input#email').css('border', '2px solid #FFFFFF');
			return true;
		}
}

function redireccionarPagina() {
  window.location = "index.html";
}

function Enviar_Correo(){
	var Vnombre = $("#txt_nombre_apellido").val();  
    var Vcorreo = $("#email").val();  
	var VComentario = $("#txt_comentario").val();  
    var Vtelefono = $("#txt_numero_telefono").val();  
	var errors = '';
	
	if ((Vnombre=='')){
		errors += '- Debe indicar un nombre';
		$("#txt_nombre_apellido").focus();
		$('#txt_nombre_apellido').css('border', '2px solid #FF0000');
		return false;
	}
	else{
		$('input#txt_nombre_apellido').css('border', '2px solid #FFFFFF');
	}
	if ((Vcorreo=='')){
		errors += '- Debe indicar un correo';
		$("#email").focus();
		$('#email').css('border', '2px solid #FF0000');
		return false;
	}
	else{
		$('input#email').css('border', '2px solid #FFFFFF');
	}
	if ((VComentario=='')){
		errors += '- Debe indicar un comentario';
		$("#txt_comentario").focus();
		$('#txt_comentario').css('border', '2px solid #FF0000');
		return false;
	}
	else{
		$('#txt_comentario').css('border', '2px solid #FFFFFF');
	}
	if ((Vtelefono=='')||($("#txt_numero_telefono").val().length < 13)){
		errors += '- Debe indicar un telefono';
		$("#txt_numero_telefono").focus();
		$('#txt_numero_telefono').css('border', '2px solid #FF0000');
		return false;
	}
	else{
		$('#txt_numero_telefono').css('border', '2px solid #FFFFFF');
	}
	
	if (errors == ''){
	var params = {
			"pNombre" : Vnombre,
			"pMail" :Vcorreo,
			"pcomentario" :VComentario,
			"pTelefono":Vtelefono
		};
			$.ajax({
			data:  params,
			url:   'enviar.php',
			dataType: 'html',
			type:  'post',
			beforeSend: function () {
				//mostramos gif "cargando"
				jQuery('#loading_spinner').show();
				//antes de enviar la petición al fichero PHP, mostramos mensaje
				jQuery("#resultado").html("Enviando...");
			},
					success:  function (response) {
					jQuery('#loading_spinner').hide();
					//mostramos salida del PHP
					jQuery("#resultado").html("Gracias nos pondremos en contacto..");
					$("#txt_nombre_apellido").val('');  
					$("#email").val('');  
					$("#txt_comentario").val('');  
					$("#txt_numero_telefono").val('');  
					$("#txt_nombre_apellido").focus();
					setTimeout('redireccionarPagina()', '5000');
					return false;
			}
		});
		}
		else{
			jQuery("#resultado").html("Error...");
			return false;
		}	
}
	








