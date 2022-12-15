import { Component, OnInit } from '@angular/core';
import { ConfirmationService, Message, MessageService } from 'primeng/api';
import { Alimento } from 'src/app/models/alimento';
import { AlimentoService } from 'src/app/services/alimento.service';

@Component({
  selector: 'app-alimento',
  templateUrl: './alimento.component.html',
  styleUrls: ['./alimento.component.scss']
})
export class AlimentoComponent implements OnInit {

  alimentos: Alimento[] = [];
  mostrarModal : boolean = false;
  mostrarModalConsulta : boolean = false;
  msgs: Message[] = [];
  alimentoSelect: Alimento = <Alimento>{};

  constructor(private alimentoService : AlimentoService, 
      private confirmationService: ConfirmationService,
      private messageService: MessageService) {        
      }

  ngOnInit(): void {
    this.obtenerAlimentos();
  }

  obtenerAlimentos() {
      this.alimentoService.obtenerAlimentos().subscribe( result => {
      this.alimentos = result;
      //console.table(this.alimentos);
  });
} 

  mostrarRegistroModal() {
    this.mostrarModal = true;
  }

  ocultarModalAgregar(cerrar : boolean) {
    this.mostrarModal = !cerrar;
    this.obtenerAlimentos();
  }

  confirmarEliminar(alimento: Alimento) {
    console.log(alimento);
    this.confirmationService.confirm({
      message:  `¿Quiere eliminar el alimento ${alimento.nombre}?`,
      header: 'Confirmación',
      icon: 'pi pi-info-circle',
      accept: () => {
          this.eliminarAlimento(alimento.idAlimento);
      },
      reject: () => {        
      }
  });
  }

  private eliminarAlimento(idAlimento?: number) {
    this.alimentoService.eliminarAlimento(idAlimento).subscribe(
      response => {
          console.log('response ', response);
          this.messageService.add({severity:'success', summary:'Alimentos', detail:'Alimento eliminado'});
          this.obtenerAlimentos();          
      }, error => {
        this.messageService.add({severity:'error', summary: 'Error', detail: 'Favor de volver a intentar'});
    });

  }

  consultarAlimento(idAlimento: number) {
    this.alimentoService.obtenerAlimento(idAlimento).subscribe(
      response => {
        this.alimentoSelect = response;        
        this.mostrarModalConsulta = true;
      });

  }


}
