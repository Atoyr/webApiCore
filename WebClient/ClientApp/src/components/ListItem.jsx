import React from 'react';
export default function ListItem({ href, text }) {
  return (
      <li><a href={href}>{text}</a></li>
  );
}