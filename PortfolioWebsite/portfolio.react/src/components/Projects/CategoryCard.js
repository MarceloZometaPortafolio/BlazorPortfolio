import React from 'react'
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
    leftAligned: {
      textAlign : "left"
    },
  }));

const CategoryCard = (props) => {
    const classes = useStyles();
    const category = props.category;

    return(
        <div>
            {props.category.map(c => 
               
                    <ul key={c.id}>
                        <li className={classes.leftAligned}>{c.name}</li>
                    </ul>
               
            )}
        </div>
    );
}

export default CategoryCard;