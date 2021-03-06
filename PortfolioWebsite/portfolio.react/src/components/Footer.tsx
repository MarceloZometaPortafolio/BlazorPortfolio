import * as React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import Typography from '@material-ui/core/Typography';
import Link from '@material-ui/core/Link';
import { Height } from '@material-ui/icons';

function Copyright() {
  return (
    <Typography variant="body2" color="textSecondary" align="center">
      {'Copyright © '}
      <Link color="inherit" href="https://material-ui.com/">
        Marcelo Zometa
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

const useStyles = makeStyles((theme) => ({
  footer: {
    backgroundColor: theme.palette.background.paper,
    // marginTop: theme.spacing(8),
    padding: theme.spacing(6, 0),
    position: "absolute",
    left: 0,
    bottom: 0,
    right: 0,
    height: "1em"
  },
}));

export default function Footer() {
  const classes = useStyles();
  
  return (
    <footer className={classes.footer}>
      <Container maxWidth="lg">        
        <Copyright />
      </Container>
    </footer>
  );
}
