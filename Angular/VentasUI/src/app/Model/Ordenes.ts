export class Ordenes {
    
    public Prioridad:string;
       public FechaRegistro:Date;
       public ValorTotal:string;
       public EstadoPedido:string;
       public Nombre:string;
       public Id:number;
       public Cliente:string;
       constructor(){
        this.Prioridad = '';
        this.FechaRegistro = new Date;
        this.ValorTotal = '';
        this.EstadoPedido = '';
        this.Nombre = '';
        this.Id = 0;
        this.Cliente = '';
    } 
}
