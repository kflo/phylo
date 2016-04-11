namespace App4.Classes.@enum
{
     public enum SequenceTypeEnum
     {
          // DNA === consisting of [A = Adenine]  [G = Guanine]  [C = Cytosine]  [T = Thymine]
          Dna = 0,
          // RNA === consisting of [A = Adenine]  [G = Guanine]  [C = Cytosine]  [U = Uracil]  
          // [I = Inosine *modified base nucleoside, part of genetic code wobble hypothesis]
          Rna = 1,
          /* Protein === consisting of  [A = Ala or Alanine]          [C = Cys or Cysteine]         [G = Gly or Glycine]
                                        [I = Ile or Isoleucine]       [L = Leu or Leucine]          [M = Met or Methionine]
                                        [P = Pro or Proline]          [S = Ser or Serine]           [T = Thr or Threonine]
                                        [V = Val or Valine]           [F = Phe or Phenylanine]      [N = Asn or Asparagine]
                                        [R = Arg or Arginine]         [Y = Tyr or Tyrosine]         [D = Asp or Aspartic Acid]
                                        [E = Glu or Glutamic Acid]    [K = Lys or Lysine]           [Q = Gln or Glutamine]
                                        [W = Trp or Tryptophan]                 [B = Asx or Aspartic Acid/Asparagine]
                                        [Z = Glx or Glutamic Acid/Glutamine]    [X = any amino acid]
                                        [J, O, U = no amino acid codes]         */
          Protein = 2,
          // Nucleotide === consisting of [A = Adenine]  [G = Guanine]  [C = Cytosine]  [T = Thymine]  [U = Uracil]
          Nucleotide = 3
     }
}