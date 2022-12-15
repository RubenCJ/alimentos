import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { Alimento } from 'src/app/models/alimento';
import { Ingrediente } from 'src/app/models/ingrediente';
import { AlimentoService } from 'src/app/services/alimento.service';

@Component({
  selector: 'app-agregar-alimento',
  templateUrl: './agregar-alimento.component.html',
  styleUrls: ['./agregar-alimento.component.scss']
})
export class AgregarAlimentoComponent implements OnInit {

  @Input() mostrarModal: boolean = true;
  @Output() clickCerrar: EventEmitter<boolean> = new EventEmitter<boolean>();

  alimentoForm : FormGroup = this.fb.group({
    nombre:['', Validators.required],
    costo:['', Validators.required],
    ingrediente:['']    
});

 ingredientes : Ingrediente[] = [];

  constructor(private fb: FormBuilder, private alimentoService: AlimentoService, 
    private messageService: MessageService) 
  {   
  }

  ngOnInit() {
  }

  cerrarModal() {
    this.ingredientes = [];
    this.alimentoForm.reset();
    this.clickCerrar.emit(true);
  }

  agregarAlimento() {

    let alimento : Alimento = this.alimentoForm.value;
    alimento.idIngredientes = this.ingredientes;

    console.log(alimento);

    this.alimentoService.guardarAlimento(this.alimentoForm.value).subscribe(
      response => {
          console.log('response ', response);
          this.messageService.add({severity:'success', summary:'Alimentos', detail:'Alimento registrado'});
          this.cerrarModal();
      }, error => {
        this.messageService.add({severity:'error', summary: 'Error', detail: 'Favor de volver a intentar'});
      });
    

  }

  crearFormulario() {
    this.alimentoForm = this.fb.group({
        nombre:['', Validators.required],
        costo:['', Validators.required],
        ingrediente:['']
    });
  }

  agregarIngrediente() {

    let ingrediente = this.alimentoForm.get('ingrediente');
    
    if(ingrediente?.value === '')  return;

    if(this.ingredientes.length >= 5) {
      this.messageService.add({severity:'warn', summary: 'Validación', detail: 'Solo se permite agregar 5 ingredientes'});
      ingrediente?.reset();
      ingrediente?.setValue('');
      return;
    }

    this.ingredientes.push( { nombre: ingrediente?.value });
    ingrediente?.reset();
    ingrediente?.setValue('');
    console.log(this.ingredientes);

  }

  get nombreValido() {
    let nombre = this.alimentoForm.get('nombre');
    return nombre?.invalid && (nombre.dirty || nombre.touched);
  }

  get costoValido() {
    let costo = this.alimentoForm.get('costo');
    return costo?.invalid && (costo.dirty || costo.touched);
  }

}
