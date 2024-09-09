using AppProjetoEscola.RegrasDeNegocios;
List<SalaDeAula> salasDeAula= new List<SalaDeAula>();

int opcao = 1;
int contador = 1;
void CadastrarTurma()
{
    int opc = 1;
    while(opc!=0)
    {
        Console.Clear();
        Console.WriteLine("------------- Cadastrar Turmas -------------\n");
        Console.WriteLine("Serie: ");
        int serie = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nome da turma:");
        var nomeTurma = Console.ReadLine();
        SalaDeAula turma = new SalaDeAula(contador, serie, nomeTurma);
        salasDeAula.Add(turma);
        contador++;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Turma cadastrada com sucesso!!!");
        Console.ForegroundColor= ConsoleColor.White;
        Console.WriteLine("Deseja continaur criando turmas??? (S/n)");
        var resp = Console.ReadLine().ToUpper();
        if (resp == "N") opc = 0;

    }
}

SalaDeAula SelecionarTurmar()
{
    Console.Clear();
    Console.WriteLine("---------------- Selecionar Turmar --------------\n");
    Console.WriteLine("Nome da Turma:");
    var nomeTurma = Console.ReadLine().ToUpper();
    var turmaSelecionada= salasDeAula.Where(sala => sala.NomeTurma.ToUpper()==nomeTurma).FirstOrDefault();
    if(turmaSelecionada== null)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Turma não encontrada!!!");
        Console.ReadKey();
    }
    Console.ForegroundColor = ConsoleColor.White;
    return turmaSelecionada;
}
 void ListarTodaEscola()
{
    Console.Clear();
    Console.WriteLine("---------------> Listar Todos Os Alunos da Escola  <-------------------\n");
    List<Aluno> todosOsAlunos = new List<Aluno>();
    foreach (var sala in salasDeAula)
    {
        todosOsAlunos.AddRange(sala.AlunosMatriculados);
    }
    foreach( var aluno in todosOsAlunos.OrderBy(u=> u.Nome).ToList())
    {
        Console.WriteLine($"Nº Matricula: {aluno.NumeroMatricula}");
        Console.WriteLine($"Nome: {aluno.Nome}");
        Console.WriteLine($"1ª Nota: {aluno.Nota1}");
        Console.WriteLine($"2ª Nota: {aluno.Nota2}");
        Console.WriteLine($"Média: {aluno.CalcularMedia()}");
        Console.WriteLine($"Situação: {aluno.VerificarSituacao()}\n");

    }
    Console.ReadKey();



}// Fim do metodo listar toda a escola

while (opcao != 0)
{
    Console.Clear();
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("                 Escola  Da Vents                 ");
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("             1 - Cadastrar Turma                  ");
    Console.WriteLine("             2 - Cadastar Aluno                   ");
    Console.WriteLine("             3 - Consultar Aluno                  ");
    Console.WriteLine("             4 - Filtar Aluno                     ");
    Console.WriteLine("             5 - Listar Alunos Aprovados          ");
    Console.WriteLine("             6 - Listar Aluno Reprovados          ");
    Console.WriteLine("             7 - Listar todos os Alunos da Turma  ");
    Console.WriteLine("             8 - Estatisticas da turma            ");
    Console.WriteLine("             9 - Listar todos os alunos da escola ");
    Console.WriteLine("             0 - Sair do Sistema                  ");



    Console.WriteLine("Digite a opção escolhida:");
    opcao = Convert.ToInt32(Console.ReadLine());
    switch (opcao)
    {
        case 1:

            CadastrarTurma();
            break;

        case 2:
            var turma = SelecionarTurmar();
            if(turma != null)salasDeAula.Where(sala => sala == turma).FirstOrDefault().CadastrarAlunos();
            break;

        case 3:
            turma = SelecionarTurmar();
           if(turma != null)  salasDeAula.Where(sala => sala == turma).FirstOrDefault().ConsultarAlunos();
            break;
        case 4:
            turma = SelecionarTurmar();
            if (turma != null) salasDeAula.Where(sala => sala == turma).FirstOrDefault().FiltarAlunos();
            break;
        case 5:
            turma = SelecionarTurmar();
            if (turma != null) salasDeAula.Where(sala => sala == SelecionarTurmar()).FirstOrDefault().ListarAlunosAprovados();
            break;
        case 6:
            turma = SelecionarTurmar();
            if (turma != null) salasDeAula.Where(sala => sala == turma).FirstOrDefault().ListarAlunosReprovados();
            break;
        case 7:
            turma = SelecionarTurmar();
            if (turma != null) salasDeAula.Where(sala => sala == turma).FirstOrDefault().ListarTodosAlunos();
            break;
        case 8:
            turma= SelecionarTurmar();
            if (turma != null) salasDeAula.Where(sala => sala == turma).FirstOrDefault().EstatisticaDaTurma();
            break;
        case 9:
            ListarTodaEscola();
            break;
        
    }
}