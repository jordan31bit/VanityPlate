/* 
 *  Vanity Plate Assignment
 *  
 *  All vanity plates must start with at least two letters.”
 *  vanity plates may contain a maximum of 6 characters(letters or numbers) and a minimum of 2 characters.”
 *  Numbers cannot be used in the middle of a plate; they must come at the end. For example, AAA222 would be an acceptable … vanity plate; AAA22A would not be acceptable.The first number used cannot be a ‘0’.”
 *  No periods, spaces, or punctuation marks are allowed.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityPlate {
    internal class Program {
        static bool checkPlateNum(String plateNum) {
            String userPlateNumber = plateNum;
            bool plateNumPassed = true;
            const int minChar = 2;
            const int maxChar = 6;

            // check min and max length of plate num
            if (userPlateNumber.Length < minChar || userPlateNumber.Length > maxChar) {
                //plateNumPassed = false;
                return false; // work around for bug
            }

            // Check first two digits to make sure they are alphabet only
            for (int i = 0; i < 2; i++) { // here lies a bug
                if (!char.IsLetter(userPlateNumber[i])) {
                    plateNumPassed = false;
                }
            }

            // Check for non-allowed characters 
            for (int i = 0; i < userPlateNumber.Length; i++) {
                if (!char.IsLetterOrDigit(userPlateNumber[i])) {
                    plateNumPassed = false;
                }
                
            }

            // Check for numbers
            for (int i = 0; i < userPlateNumber.Length; i++) {
                // find first number
                if (char.IsDigit(userPlateNumber[i])) {
                    // Check if first number is 0. That is a no no.
                    if (userPlateNumber[i] == '0') {
                        plateNumPassed = false;   
                    }
                    // check if numbers are interrupted by alphabet
                    for (int j = i; j < userPlateNumber.Length - i; j++) {
                        if (char.IsLetter(userPlateNumber[j])) {
                            plateNumPassed = false;
                        }
                    }

                    break;
                }
            }
            return plateNumPassed;
        }
        static void Main(string[] args) {
            String userPlateNumber;
            bool isValid;

            // Get user plate number input and pass it to checkPlateNum function
            Console.Write("Please enter a license plate number: ");
            userPlateNumber = Console.ReadLine();
            isValid = checkPlateNum(userPlateNumber);

            if(isValid) {
                Console.WriteLine("The plate number {0} is VALID.", userPlateNumber);
            }
            else {
                Console.WriteLine("The plate number {0} is NOT VALID.", userPlateNumber);
            }
            
            Console.Read();
        }
    }
}
