import React, { useEffect, useState } from 'react'
import { Card, CardContent, CardHeader } from '@material-ui/core';
import APIService from '../../Data/APIService'
import { makeStyles } from '@material-ui/core/styles';
import CategoryCard from '../Projects/CategoryCard';

const useStyles = makeStyles((theme) => ({
    leftAligned: {
      textAlign : "left"
    },
  }));

const Languages = (props) => {              
    const [languages, setLanguages] = useState([]);        
    const classes = useStyles();

    const getLanguages = async() => {
        const languages = await APIService.getLanguages();

        return languages;
    }

    useEffect(() => {       
        getLanguages()
        .then(languagesFound => {
            setLanguages(languagesFound);
        })                        
    }, []);

    return(
        <div>
            <Card>
                <CardHeader title={"Languages"}/>
                <CardContent>                    
                {languages.map(c => 
               
               <ul key={c.id}>
                   <li className={classes.leftAligned}>{c.name}</li>
               </ul>
          
       )}
                </CardContent>
            </Card>
        </div>
    );
}

export default Languages