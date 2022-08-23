using System;

namespace ProgVelhaGame
{
    internal class Program
    {
        static void TabuleiroInicial(string[,] board)
        {
            board[0, 0] = "1";
            board[0, 1] = "2";
            board[0, 2] = "3";
            board[1, 0] = "4";
            board[1, 1] = "5";
            board[1, 2] = "6";
            board[2, 0] = "7";
            board[2, 1] = "8";
            board[2, 2] = "9";

        }
        static void EstruturaTabuleiro(string[,] board)
        {
            Console.Clear();
            Console.Write("\t\tColunas\t\n");
            Console.Write("Linhas ");

            for (int i = 0; i < 3; i++)
            {
                Console.Write("\t" + board[i, 0] + "  |");

                Console.Write("\t" + board[i, 1] + "  |");

                Console.Write("\t" + board[i, 2] + "  \n");
            }
        }
        static void Posicao(string[,] board)
        {
            int cont = 0;
            int jog = 1;
            string[] controlePosicao = new string[9];
            bool ganhou = false;
            string posicao = "0";
            int i = 0;
            int posicaoNumerico = -1;
            do
            {
                bool posicaoUtilizada = false;
                do
                {
                    if (jog == 1)
                    {
                        Console.Write("Jogador " + jog + " que posicao deseja colocar X: ");
                    }
                    else
                    {
                        Console.Write("Jogador " + jog + " que posicao deseja colocar O: ");
                    }
                    posicao = Console.ReadLine();

                    int.TryParse(posicao, out posicaoNumerico);

                    if (posicaoNumerico < 1 || posicaoNumerico > 9)
                    {
                        Console.WriteLine(" Posicao incorreta, digite um numero entre 1 e 9 ");

                    }

                   
                    for (i = 0; i < controlePosicao.Length; i++)
                    {
                        if (controlePosicao[i] == posicao)
                        {
                            posicaoUtilizada = true;
                            Console.WriteLine(" Posicao ja foi digitada, digite outra posicao ou uma posicao valida ");
                        }
                    }
                } while (posicaoNumerico<1 || posicaoNumerico>9);
                    if (posicaoUtilizada == false)
                    {
                        //preencho matriz de acordo com a posicao escolhida e a peça do jogador
                        for (i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (board[i, j] == posicao)
                                {
                                    if (jog == 1)
                                    {
                                        board[i, j] = "X";
                                    }
                                    else
                                    {
                                        board[i, j] = "O";
                                    }
                                }
                            }
                        }

                        controlePosicao[cont] = posicao;
                        EstruturaTabuleiro(board);
                       ganhou = Ganhador(board,jog);
                        
                        cont++;
                    }
                
                if (ganhou==true)
                {
                    Console.Write("O jogador "+jog+" venceu");
                    return;
                }
                jog++;
                //qual jogador é
                if (jog > 2)
                {
                    jog = 1;
                }

            } while (cont < 9 && ganhou==false);
            Console.WriteLine("Deu velha!");
        }
        static bool Ganhador(string[,] board, int jog)
        {
            //linhas X

            if (board[0, 0]=="X" && board[0, 1] =="X"&& board[0, 2]=="X")
            {
          
                return true;
            }
            else if (board[1, 0]=="X"&& board [1,0]==board[1,1]&& board[1, 1] == board[1, 2] )
            {
                return true;
            }
            else if (board[2, 0]=="X" && board[2,0]== board[2,1] && board[2, 1] == board[2, 2])
            {
                return true;
            }

            //colunas X
            else if (board[0, 0] =="X" && board[0,0]== board[1, 0] && board[1,0]==board[2, 0])
            {
                return true;
            }
            else if (board[0, 1] == "X"&& board[0,1]==board[1, 1]&& board[1,1] == board[2, 1] )
            {
                return true;
            }
            else if (board[0, 2] =="X" &&board[0,2]==board[1, 2] && board[1,2] == board[2, 2])
            {
                return true;
            }
            //diagonais X
            else if (board[0, 0]=="X"&& board[0,0]== board[1, 1] && board[1,1] == board[2, 2])
            {
                return true;
            }
            else if
            (board[2, 0]=="X" && board[2,0]== board[1, 1] && board[1,1] == board[0, 2] )
            {
                return true;
            }
            //linhas O
            else if (board[0, 0] == "O" && board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2])
            {
                return true;
            }

            else if (board[1, 0] == "O" && board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2])
            {
                return true;
            }

            else if (board[2, 0] =="O" && board[2,0]== board[2,1]&& board[2,1]== board[2,2])
            {
                return true;
            }
            //colunas O
            else if (board[0, 0] =="O"&& board[0,0]==board[1, 0] && board[1,0]==board[2, 0] )
            {
                return true;
            }
            else if (board[0, 1] =="O" && board[0,1]==board[1, 1]&& board[1,1]== board[2, 1] )
            {
                return true;
            }

            else if (board[0, 2] == "O" && board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2])
            {
                return true;
            }
            //diagonais O
            else if (board[0, 0] == "O" && board[0,0]==board[1, 1] && board[1,1] ==board[2, 2])
            {
                return true;
            }

            else if (board[2, 0] =="O" && board[2,0]== board[1, 1] && board[1,1] == board[0, 2] )
            {
                return true;
            }
            else
            {
                
                return false;
            }

        }
        static void Main(string[] args)
        {
            string[,] quadrado = new string[3, 3];
            //imprime o tabuleiro
            TabuleiroInicial(quadrado);
            EstruturaTabuleiro(quadrado);
            //jogo
            Posicao(quadrado);
        }
    }
}

