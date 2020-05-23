using System;

namespace vs_first_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do Aluno");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do Aluno");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Notas = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da Nota deve ser decimal");
                        }

                        alunos[indiceAluno] =  aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Notas}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        int nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Notas;
                                nrAlunos++;
                            }
                        }
                            var mediaGeral = notaTotal / nrAlunos;
                            Conceito conceitoGeral;

                            if (mediaGeral < 2)
                            {
                                conceitoGeral = Conceito.E;
                            }
                            else if (mediaGeral < 4)
                            {
                                conceitoGeral = Conceito.D;
                            }
                            else if (mediaGeral < 6)
                            {
                                conceitoGeral = Conceito.C;
                            }
                            else if (mediaGeral < 8)
                            {
                                conceitoGeral = Conceito.B;
                            }
                            else
                            {
                                conceitoGeral = Conceito.A;
                            }

                            Console.WriteLine($"A média geral é {mediaGeral} - Conceito: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular media Geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
