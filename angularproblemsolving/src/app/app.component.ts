import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'Welcome To Problem Solving';
    reversemsg = "";
    ErrMsg1 = "";
    ErrMsg2 = "";
    keyvals=[];

    public testForm: FormGroup = new FormGroup({
        'txt1': new FormControl()
    });

    Reverse() {
        this.reversemsg = "";
        let objForm = this.testForm.value;
        let txt1 = objForm.txt1;
        if (txt1 != null && txt1.length > 0) {
            let strword = "";
            for (let i = 0; i < txt1.length; i++) {

                if (txt1[i] == " ") {
                    for (let j = strword.length - 1; j >= 0; j--) {
                        this.reversemsg = this.reversemsg + strword[j];
                    }
                    this.reversemsg = this.reversemsg + " ";
                    strword = "";
                }
                strword = strword + txt1[i];

                if (i == txt1.length - 1) {
                    for (let j = strword.length - 1; j >= 0; j--) {
                        this.reversemsg = this.reversemsg + strword[j];
                    }
                }
            }
        }
        else{
            this.ErrMsg1 = "Please enter any text";
        }
    }

    public findkeysForm: FormGroup = new FormGroup({
        'txtkeys': new FormControl()
    });

    FindKeys(){
        this.keyvals = [];
        let objForm = this.findkeysForm.value;
        let txtval = objForm.txtkeys;
        let keyarr = txtval.split(':');
        for(let key in keyarr){
            if(parseInt(key) < keyarr.length-1){
                let x = keyarr[key].split(',')
                if(x.length>1){
                    console.log(x[1]);
                    // keyvals
                    this.keyvals.push(x[1])
                }
                else{
                    this.keyvals.push(keyarr[key].replace("{",""))
                }
            }
        }        
    }

    
}
